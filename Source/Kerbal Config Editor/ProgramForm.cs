using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KerbalConfigEditor
{
    public partial class ProgramForm : Form
    {
        #region Variables
        /************************ Variables ************************/

        // The current root ConfigNode of this project.
        private ConfigNode currentRootNode;
        // The currently selected ConfigNode. This corresponds to nodeView.SelectedNode
        // and selectedTreeNode, which are TreeNodes.
        private ConfigNode selectedConfigNode;
        // The currently selected TreeNode. This corresponds to nodeView.SelectedNode,
        // which is also a TreeNode, and selectedConfigNode, which is a ConfigNode.
        private TreeNode selectedTreeNode;

        // Indicates whether or not the current project is new. If it is, then this
        // project has never been saved before. Thus, we don't know where to save it
        // without asking the user.
        private bool currentIsNew = true;
        // Indicates whether or not there are unsaved changes in the current project.
        private bool changesUnsaved = false;
        // Indicates whether or not there are unsaved values in the currently selected node.
        private bool valuesUnsaved = false;

        // An incrementing integer used to create new ConfigNode values.
        private int valueIncrement = 1;
        // A static incrementing integer used to apply unique strings to ConfigNode IDs. 
        private static int cfgIncrement = 0;

        // The path used to check for and save autosaved files.
        private string autosavePath = Directory.GetCurrentDirectory() + "\\KCE_Data\\Autosave\\autosave.cfg";
        #endregion

        #region Form
        /************************ Form ************************/

        /// <summary>
        /// Creates an instance of the ProgramForm.
        /// </summary>
        public ProgramForm()
        {
            // Initialize the form.
            InitializeComponent();
        }

        /// <summary>
        /// When the ProgramForm instance loads.
        /// </summary>
        /// <param name="sender">The object sending the event.</param>
        /// <param name="e">The event arguments.</param>
        private void ProgramForm_Load(object sender, EventArgs e)
        {
            // If an autosaved file is found,
            if (File.Exists(autosavePath))
            {
                // Tell the user that a file has been found, and ask if he wishes to recover it.
                DialogResult res = System.Windows.Forms.MessageBox.Show("Kerbal Config Editor has recovered a config file from its last session. Do you wish to recover this file? Selecting No will remove this file permanently.", "Recover Config File?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // If the user has selected Yes,
                if (res == System.Windows.Forms.DialogResult.Yes)
                {
                    // Open the autosave file.
                    OpenFile(autosavePath);
                }
                else
                {
                    // Otherwise, create a new ConfigNode project.
                    newToolStripMenuItem_Click(this, null);
                }
            }
            else
            {
                // Otherwise, create a new ConfigNode project.
                newToolStripMenuItem_Click(this, null);
            }
        }

        /// <summary>
        /// When the form is closing.
        /// </summary>
        /// <param name="sender">The object sending the event.</param>
        /// <param name="e">The event arguments.</param>
        private void ProgramForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // If the form is closing due to the user pressing the X button, or if the internal code is closing,
            if (e.CloseReason == CloseReason.UserClosing || e.CloseReason == CloseReason.ApplicationExitCall)
            {
                // If there are unsaved changes,
                if (changesUnsaved)
                {
                    // Ask the user if the changes should be saved.
                    DialogResult res = System.Windows.Forms.MessageBox.Show("Save changes to current node project before closing?", "Save changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    // If the user wishes to cancel, cancel the close event.
                    // If the user wishes to save, save the file, and then close.
                    switch(res)
                    {
                        case System.Windows.Forms.DialogResult.Cancel:
                            {
                                e.Cancel = true;
                                break;
                            }
                        case System.Windows.Forms.DialogResult.Yes:
                            {
                                saveToolStripMenuItem_Click(this, null);
                                break;
                            }
                    }

                    // If the user selects No, then no further action is needed, as the current
                    // project's changes are discarded automatically, and the form closes.
                }
            }
            // Otherwise, if Windows is shutting down, create an autosave file for recovery later.
            else if (e.CloseReason == CloseReason.WindowsShutDown)
            {
                // Save the autosave file.
                ConfigUtil.SaveConfigFile(currentRootNode, autosavePath);
            }
        }
        #endregion

        #region File
        /************************ File ************************/

        /// <summary>
        /// When the New menu item is clicked.
        /// </summary>
        /// <param name="sender">The object sending the event.</param>
        /// <param name="e">The event arguments.</param>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create a temporary "proceed" Boolean variable.
            bool proceed = false;

            // If changes are unsaved,
            if (changesUnsaved)
            {
                // Ask if the user wishes to discard the changes or cancel. If the user wishes to discard,
                if (System.Windows.Forms.MessageBox.Show("Are you sure you want to discard all unsaved changes?", "Discard Changes?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    // Set proceed to true. We may proceed to make a new ConfigNode project.
                    proceed = true;
                }
            }
            else
            {
                // Otherwise, set proceed to true. We may proceed to make a new ConfigNode project.
                proceed = true;
            }

            // If we may proceed,
            if (proceed)
            {
                // Create a brand spanking new configNode and set its ID to a new unique string.
                currentRootNode = new ConfigNode();
                currentRootNode.id = GetUniqueString();

                // Update the tree view.
                UpdateTreeView();

                // There are no unsaved changes, since the node is new.
                changesUnsaved = false;
                // The node is new, so we want to indicate that we have no place to save it without asking.
                currentIsNew = true;

                // Change the title to reflect the new untitled project.
                this.Text = "Kerbal Config Editor - Untitled.cfg";
            }
        }

        /// <summary>
        /// When the Open menu item is clicked.
        /// </summary>
        /// <param name="sender">The object sending the event.</param>
        /// <param name="e">The event arguments.</param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create a temporary "proceed" Boolean variable.
            bool proceed = false;

            // If changes are unsaved,
            if (changesUnsaved)
            {
                // Ask if the user wishes to discard the changes or cancel. If the user wishes to discard,
                if (System.Windows.Forms.MessageBox.Show("Are you sure you want to discard all unsaved changes?", "Discard Changes?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    // Set proceed to true. We may proceed to load a ConfigNode project.
                    proceed = true;
                }
            }
            else
            {
                // Otherwise, set proceed to true. We may proceed to make a new ConfigNode project.
                proceed = true;
            }

            // If we may proceed,
            if (proceed)
            {
                // Get the results of showing the Open File Dialog.
                DialogResult res = openConfigDialog.ShowDialog(this);

                // If the result was OK, begin loading the file.
                if (res == System.Windows.Forms.DialogResult.OK)
                {
                    // Open the file.
                    OpenFile(openConfigDialog.FileName);
                }
            }
        }

        /// <summary>
        /// When the Save menu item is clicked.
        /// </summary>
        /// <param name="sender">The object sending the event.</param>
        /// <param name="e">The event arguments.</param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // If the current project is new, we don't know where to save it without asking.
            if (currentIsNew)
            {
                // Save it using the Save As function, which provides us exactly the functionality we need.
                saveAsToolStripMenuItem_Click(sender, e);
            }
            else
            {
                // If the project isn't new, we know where to save it. Attempt to save it until either the user cancels, or the save succeeds.
                DialogResult res = System.Windows.Forms.DialogResult.OK;
                bool success = false;

                // Try once.
                do
                {
                    // Save.
                    success = ConfigUtil.SaveConfigFile(currentRootNode, saveConfigDialog.FileName);

                    // If the file didn't save,
                    if (!success)
                    {
                        // Tell the user that the file couldn't be saved, and ask if they wish to retry.
                        res = System.Windows.Forms.MessageBox.Show("Error: Could not save file to that location.", "Error: Couldn't Save File", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    }
                    // If the save was unsuccessful, and the user wants to retry, repeat this again.
                } while (!success && res == System.Windows.Forms.DialogResult.Retry);

                // Sets changesUnsaved based on whether success was had or not.
                // If the code reaches this point without success, then the user
                // canceled and there are still unsaved changes.
                changesUnsaved = !success;
            }
        }

        /// <summary>
        /// When the Save As menu item is clicked.
        /// </summary>
        /// <param name="sender">The object sending the event.</param>
        /// <param name="e">The event arguments.</param>
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Firstly, let's be sure it isn't just an empty project.
            if (currentRootNode.nodes.Count > 0 || currentRootNode.values.Count > 0)
            {
                // Show the Save File Dialog.
                DialogResult res = saveConfigDialog.ShowDialog();

                // If the user returns with an OK,
                if (res == System.Windows.Forms.DialogResult.OK)
                {
                    // Attempt to save it until either the user cancels, or the save succeeds.
                    bool success = false;

                    // Try once.
                    do
                    {
                        // Save.
                        success = ConfigUtil.SaveConfigFile(currentRootNode, saveConfigDialog.FileName);

                        // If the file didn't save,
                        if (!success)
                        {
                            // Tell the user that the file couldn't be saved, and ask if they wish to retry.
                            res = System.Windows.Forms.MessageBox.Show("Error: Could not save file to that location.", "Error: Couldn't Save File", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                        }
                        // If the save was unsuccessful, and the user wants to retry, repeat this again.
                    } while (!success && res == System.Windows.Forms.DialogResult.Retry);

                    // Sets changesUnsaved and currentIsNew based on whether success was had or not.
                    // If the code reaches this point without success, then the user canceled and
                    // there are still unsaved changes.
                    changesUnsaved = !success;
                    currentIsNew = changesUnsaved;
                }
            }
            else
            {
                // If it is an empty project, deny saving.
                System.Windows.Forms.MessageBox.Show("Error: One does not simply save an empty config project.", "Error: Can't Save Empty Config", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// When the Exit menu item is clicked.
        /// </summary>
        /// <param name="sender">The object sending the event.</param>
        /// <param name="e">The event arguments.</param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Exit the application.
            Application.Exit();
        }
        #endregion

        #region Help
        /************************ Help ************************/
        
        /// <summary>
        /// When the About menu item is clicked.
        /// </summary>
        /// <param name="sender">The object sending the event.</param>
        /// <param name="e">The event arguments.</param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog(this);
        }
        #endregion

        #region New Buttons
        /************************ New Buttons ************************/

        /// <summary>
        /// When the New Node button is clicked.
        /// </summary>
        /// <param name="sender">The object sending the event.</param>
        /// <param name="e">The event arguments.</param>
        private void buttonNewNode_Click(object sender, EventArgs e)
        {
            // Create a new ConfigNode, named "NewNode".
            ConfigNode newNode = new ConfigNode("NewNode");

            // Set its ID to a new unique string.
            newNode.id = GetUniqueString();

            // Add the newly created ConfigNode as a child to the currently selected node.
            selectedConfigNode.AddNode(newNode);

            // Create a new TreeNode, add it as a child to the currently selected node, and select it.
            TreeNode newTreeNode = AddNodeToTree(newNode, nodeView.SelectedNode);
            nodeView.SelectedNode = newTreeNode;

            // Indicate unsaved changes to the file.
            changesUnsaved = true;
        }

        /// <summary>
        /// When the New Value button is clicked.
        /// </summary>
        /// <param name="sender">The object sending the event.</param>
        /// <param name="e">The event arguments.</param>
        private void buttonNewValue_Click(object sender, EventArgs e)
        {
            // Add a new value named "newValue" plus an incremented number to the currently selected ConfigNode.
            selectedConfigNode.AddValue("newValue" + valueIncrement++.ToString(), "value");

            // Update the value table.
            UpdateValueTable();
        }
        #endregion

        #region Tree View Manager
        /************************ Tree View Manager ************************/

        /// <summary>
        /// Fired just before a new node is selected, allowing us to check for unsaved values and ask if they should be saved.
        /// </summary>
        /// <param name="sender">The object sending the event.</param>
        /// <param name="e">The event arguments.</param>
        private void nodeView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            // If the values are unsaved,
            if (valuesUnsaved)
            {
                // Ask if the user wants to save them, discard the changes, or cancel.
                DialogResult res = System.Windows.Forms.MessageBox.Show("Do you want to save the modified values before selecting another node?", "Save Modified Values?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                switch(res)
                {
                    // If they want to save, save.
                    case System.Windows.Forms.DialogResult.Yes:
                        {
                            saveValuesButton_Click(this, null);
                            break;
                        }
                    // If they want to cancel, cancel.
                    case System.Windows.Forms.DialogResult.Cancel:
                        {
                            e.Cancel = true;
                            break;
                        }
                }

                // No action is needed if the user doesn't wish to save the values or cancel.
                // The new node will be selected and the changes discarded automatically.
            }
        }

        /// <summary>
        /// Fired just after a new node is selected, allowing us to get the corresponding ConfigNode
        /// </summary>
        /// <param name="sender">The object sending the event.</param>
        /// <param name="e">The event arguments.</param>
        private void nodeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // The values have no unsaved changes since we're only just getting them.
            valuesUnsaved = false;

            // Get the selected tree node and use its name to get the corresponding ConfigNode.
            // (Each tree node's name corresponds to a ConfigNode's ID value, created using the
            // unique string generator, making finding a ConfigNode extremely easy.)
            selectedTreeNode = e.Node;
            selectedConfigNode = ConfigUtil.GetNodeById(currentRootNode, e.Node.Name);

            // If the selected node is the root node, do not allow editing, since this root node is
            // normally invisible in the config file. Otherwise, enable editing of the node's properties.
            if (selectedConfigNode == currentRootNode)
            {
                nodeNameField.Enabled = false;
                nodeNameButton.Enabled = false;
                nodeRemoveButton.Enabled = false;
                nodeNameField.Text = "Root";
            }
            else
            {
                nodeNameField.Enabled = true;
                nodeNameButton.Enabled = true;
                nodeRemoveButton.Enabled = true;
                nodeNameField.Text = selectedConfigNode.name;
            }

            // Finally, update the table, displaying the new values.
            UpdateValueTable();
        }

        /// <summary>
        /// Updates the Tree View, displaying TreeNodes corresponding to the ConfigNodes.
        /// </summary>
        private void UpdateTreeView()
        {
            // Suspend layout logic.
            nodeView.SuspendLayout();
            // Clear all nodes.
            nodeView.Nodes.Clear();
            // Add the root ConfigNode to the tree. This function recurses through all contained nodes as well.
            TreeNode root = AddNodeToTree(currentRootNode, null);
            // Select the root node.
            nodeView.SelectedNode = root;
            // Resume layout logic, refusing pending layout requests, and manually perform layout once.
            nodeView.ResumeLayout(false);
            nodeView.PerformLayout();
        }

        /// <summary>
        /// Adds a TreeNode to the tree view, or the provided parent TreeNode if not null. This function recurses through all child ConfigNodes of the provided node.
        /// </summary>
        /// <param name="node">The ConfigNode to add and recurse through.</param>
        /// <param name="currentNode">The TreeNode to add all created nodes to. If null, the created TreeNode is added to the TreeView directly.</param>
        /// <returns>The created TreeNode.</returns>
        private TreeNode AddNodeToTree(ConfigNode node, TreeNode currentNode)
        {
            // Create a new TreeNode, naming it after the corresponding ConfigNode, or "Root" if the corresponding node's name is null or empty.
            TreeNode newNode = new TreeNode((node.name == null || node.name == "" ? "Root" : node.name));
            // Set the new TreeNode's name to the ID of the corresponding ConfigNode. This is how we find ConfigNodes using TreeNodes.
            newNode.Name = node.id;

            // For each child ConfigNode inside the provided node, add it to the tree as well, providing the current TreeNode as a parent.
            foreach (ConfigNode n in node.nodes)
            {
                AddNodeToTree(n, newNode);
            }

            // If a TreeNode was not provided to parent the created node to, add it to the TreeView directly.
            // Otherwise, add it to the provided parent TreeNode.
            if (currentNode != null)
            {
                currentNode.Nodes.Add(newNode);
            }
            else
            {
                nodeView.Nodes.Add(newNode);
            }

            // Return the newly created node. This is used to select the newly created node.
            // If this function is a recurse, it is not used.
            return newNode;
        }
        #endregion

        #region Node Editor Manager
        /************************ Node Editor Manager ************************/

        /// <summary>
        /// When the Update Name button is clicked.
        /// </summary>
        /// <param name="sender">The object sending the event.</param>
        /// <param name="e">The event arguments.</param>
        private void nodeNameButton_Click(object sender, EventArgs e)
        {
            // If the field is empty,
            if (nodeNameField.Text == "")
            {
                // Alert the user that the node's name cannot be empty.
                System.Windows.Forms.MessageBox.Show("Error: The node name cannot be blank.", "Error: Blank Node Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nodeNameField.Text = selectedTreeNode.Text;
            }
            else
            {
                // Otherwise, set the selected node's name to the text inside the field.
                selectedConfigNode.name = nodeNameField.Text;
                selectedTreeNode.Name = nodeNameField.Text;
                selectedTreeNode.Text = nodeNameField.Text;
                // Also, indicate that unsaved changes were made.
                changesUnsaved = true;
            }
        }

        /// <summary>
        /// When the Remove Node button is clicked.
        /// </summary>
        /// <param name="sender">The object sending the event.</param>
        /// <param name="e">The event arguments.</param>
        private void nodeRemoveButton_Click(object sender, EventArgs e)
        {
            // Remove the selected node from its parent node.
            ConfigNode selectedConfigTemp = selectedConfigNode;
            selectedConfigNode = ConfigUtil.GetParentOfNode(selectedConfigTemp, currentRootNode);
            selectedConfigNode.nodes.Remove(selectedConfigTemp);

            // Remove the node's corresponding tree node from the tree view.
            TreeNode selectedTreeTemp = selectedTreeNode;
            nodeView.SelectedNode = selectedTreeTemp.Parent;
            selectedTreeTemp.Remove();
            // Also, indicate that unsaved changes were made.
            changesUnsaved = true;
        }

        /// <summary>
        /// When the Save Values button is clicked.
        /// </summary>
        /// <param name="sender">The object sending the event.</param>
        /// <param name="e">The event arguments.</param>
        private void saveValuesButton_Click(object sender, EventArgs e)
        {
            // Make two lists, one for the name fields, and one for the value fields.
            List<TextBox> nameFields = new List<TextBox>();
            List<TextBox> valFields = new List<TextBox>();

            // Iterate through each Component in the table's Controls list.
            foreach(Component c in valuesTable.Controls)
            {
                // If c's type is of TextBox,
                if (c.GetType() == typeof(TextBox))
                {
                    // Cast it into a text box.
                    TextBox field = (TextBox)c;

                    // If the name contains "NameField", then it is a name field. Add it into the nameFields list.
                    // Otherwise, if it contains "ValueField", it is a value field. Add it into the valueFields list.
                    if (field.Name.Contains("NameField"))
                    {
                        nameFields.Add(field);
                    }
                    else if (field.Name.Contains("ValueField"))
                    {
                        valFields.Add(field);
                    }
                }
            }


            // Iterate through the two lists, using for.
            for (int i = 0; i < nameFields.Count; i++)
            {
                // Get the name and value indicated in the two fields.
                string valName = nameFields[i].Name.Substring(0, nameFields[i].Name.Length - 9);
                string valVal = valFields[i].Text;
                // If the field's value name doesn't match the current value's name,
                if (valName != nameFields[i].Text)
                {
                    // Remove the old value and recreate it.
                    selectedConfigNode.RemoveValue(valName);
                    selectedConfigNode.AddValue(nameFields[i].Text, valVal);
                    nameFields[i].Name = nameFields[i].Text + "NameField";
                    valFields[i].Name = nameFields[i].Text + "ValueField";
                }
                else
                {
                    // Otherwise, just set the value of the existing one, since its name didn't change.
                    selectedConfigNode.SetValue(valName, valVal);
                }
            }

            // Call ValuesSaved, which shows the status bar indicator for a short time.
            ValuesSaved();
        }

        /// <summary>
        /// Shows the "Values Saved" status bar indicator for 3 seconds (3000 milliseconds), and then hide it.
        /// </summary>
        private async void ValuesSaved()
        {
            // Set Visible to true.
            toolStripSavedLabel.Visible = true;
            // Wait 3 seconds.
            await Task.Delay(3000);
            // Set Visible to false.
            toolStripSavedLabel.Visible = false;
        }

        /// <summary>
        /// Updates the Value Table, redisplaying the values in the current node.
        /// </summary>
        private void UpdateValueTable()
        {
            // Make it invisuble and suspend the layout.
            valuesTable.Visible = false;
            valuesTable.SuspendLayout();

            // Clear it.
            ClearValueTable();

            int row = 0;

            // For each value in the node,
            foreach (ConfigNode.Value v in selectedConfigNode.values)
            {
                // Add it into the table, incrementing row.
                AddValueToTable(v, row);
                row++;
            }

            // Resume layout logic, refusing pending layout requests, and manually perform layout once.
            valuesTable.ResumeLayout(false);
            valuesTable.PerformLayout();

            // Also, make it visible and enable the save values button if there are any values.
            valuesTable.Visible = (row > 0);
            saveValuesButton.Enabled = (row > 0);
        }

        /// <summary>
        /// Adds the specified value into the specified row in the Values Table.
        /// </summary>
        /// <param name="val">The value to add.</param>
        /// <param name="row">The row to place the Controls.</param>
        private void AddValueToTable(ConfigNode.Value val, int row)
        {
            // Add the name label and format it.
            Label nameLabel = new Label();
            nameLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(2, 8);
            nameLabel.Margin = new System.Windows.Forms.Padding(0);
            nameLabel.Name = val.name+"NameLabel";
            nameLabel.Size = new System.Drawing.Size(35, 13);
            nameLabel.TabIndex = 0;
            nameLabel.Text = "Name";

            // Add the name field and format it.
            TextBox nameField = new TextBox();
            nameField.Dock = System.Windows.Forms.DockStyle.Fill;
            nameField.Location = new System.Drawing.Point(47, 5);
            nameField.Name = val.name + "NameField";
            nameField.Size = new System.Drawing.Size(229, 20);
            nameField.TabIndex = 1;
            nameField.Text = val.name;
            nameField.TextChanged += new EventHandler(valueField_TextChanged);

            // Add the equals label and format it.
            Label equalsLabel = new Label();
            equalsLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            equalsLabel.AutoSize = true;
            equalsLabel.Location = new System.Drawing.Point(281, 8);
            equalsLabel.Margin = new System.Windows.Forms.Padding(0);
            equalsLabel.Name = val.value + "ValueLabel";
            equalsLabel.Size = new System.Drawing.Size(19, 13);
            equalsLabel.TabIndex = 0;
            equalsLabel.Text = " = ";

            // Add the equals field and format it.
            TextBox equalsField = new TextBox();
            equalsField.Dock = System.Windows.Forms.DockStyle.Fill;
            equalsField.Location = new System.Drawing.Point(306, 5);
            equalsField.Name = val.value + "ValueField";
            equalsField.Size = new System.Drawing.Size(229, 20);
            equalsField.TabIndex = 2;
            equalsField.Text = val.value;
            equalsField.TextChanged += new EventHandler(valueField_TextChanged);

            // Add the remove button and format it.
            Button removeButton = new Button();
            removeButton.Location = new System.Drawing.Point(543, 5);
            removeButton.Name = val.name + "Remove";
            removeButton.Size = new System.Drawing.Size(24, 20);
            removeButton.TabIndex = 4;
            removeButton.Text = "X";
            removeButton.UseVisualStyleBackColor = true;
            removeButton.Click += new EventHandler(removeButtonX_Click);

            // Add them to the table.
            valuesTable.Controls.Add(nameLabel, 0, row);
            valuesTable.Controls.Add(nameField, 1, row);
            valuesTable.Controls.Add(equalsLabel, 2, row);
            valuesTable.Controls.Add(equalsField, 3, row);
            valuesTable.Controls.Add(removeButton, 4, row);
        }

        /// <summary>
        /// Clears the table, disposing of all controls inside.
        /// </summary>
        private void ClearValueTable()
        {
            while (valuesTable.Controls.Count > 0) valuesTable.Controls[0].Dispose();
        }

        /// <summary>
        /// Fired when either the value name or value value fields are changed, indicating unsaved values.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void valueField_TextChanged(object sender, EventArgs e)
        {
            // The fields have changed, so the values now have unsaved changes.
            valuesUnsaved = true;
        }

        /// <summary>
        /// Fired when a value's remove button is clicked.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void removeButtonX_Click(object sender, EventArgs e)
        {
            // Cast the sender into a Button.
            Button clicked = (Button)sender;
            // Get the value's name.
            string valueRemoving = clicked.Name.Substring(0, clicked.Name.Length - 6);
            // Remove the value.
            selectedConfigNode.RemoveValue(valueRemoving);
            //Update the table.
            UpdateValueTable();
        }
        #endregion

        #region Util
        /************************ Util ************************/

        /// <summary>
        /// Opens the specified config file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        private void OpenFile(string filePath)
        {
            // Make the progress indicators visible.
            toolStripProgressLabel.Visible = true;
            toolStripProgressBar.Visible = true;
            // Make the form display the wait cursor, indicating work is being done.
            UseWaitCursor = true;

            // Disabe various controls that shouldn't be used at the moment.
            buttonNewNode.Enabled = false;
            buttonNewValue.Enabled = false;
            nodeNameField.Enabled = false;
            nodeNameButton.Enabled = false;
            nodeRemoveButton.Enabled = false;
            saveValuesButton.Enabled = false;

            // Including the New, Open, Save, and Save As options.
            newToolStripMenuItem.Enabled = false;
            openToolStripMenuItem.Enabled = false;
            saveToolStripMenuItem.Enabled = false;
            saveAsToolStripMenuItem.Enabled = false;

            // Clear all TreeNodes from the tree view.
            nodeView.Nodes.Clear();

            // Create the background worker which will load the file, allowing responsive UI.
            BackgroundWorker bw = new BackgroundWorker();
            // This worker should report the progress, yes.
            bw.WorkerReportsProgress = true;

            // Set the work for the worker to do when it does work.
            bw.DoWork += (sender1, args) =>
            {
                currentRootNode = ConfigUtil.LoadConfigFile(filePath, sender1 as BackgroundWorker);
            };

            // Tell the worker how to report progress.
            bw.ProgressChanged += (sender1, args) =>
            {
                toolStripProgressBar.Value = args.ProgressPercentage.Clamp(0, 100);
            };

            // Tell the worker what to do when its work is completed.
            bw.RunWorkerCompleted += (sender1, args) =>
            {
                if (args.Error != null)
                    System.Windows.Forms.MessageBox.Show(args.Error.ToString());

                FinishOpeningFile();
            };

            // Run the worker.
            bw.RunWorkerAsync();
        }

        /// <summary>
        /// Performs final UI operations once the file has openned and parsed.
        /// </summary>
        private void FinishOpeningFile()
        {
            // Sets the save dialog's file name to the open dialog's file name.
            // This is so that the save functions can simply always pull from
            // the save dialog instead of having to perform additonal logic.
            saveConfigDialog.FileName = openConfigDialog.FileName;

            // Update the tree view with the loaded ConfigNode.
            UpdateTreeView();
            // The node was just created, so there are no unsaved changes.
            changesUnsaved = false;
            // This node was created from file, so we can get that file's
            // location later when we want to save it again.
            currentIsNew = false;

            // Re-enable the New Buttons.
            buttonNewNode.Enabled = true;
            buttonNewValue.Enabled = true;

            // And the New, Open, Save, and Save As options.
            newToolStripMenuItem.Enabled = true;
            openToolStripMenuItem.Enabled = true;
            saveToolStripMenuItem.Enabled = true;
            saveAsToolStripMenuItem.Enabled = true;

            // Change the form's title to reflect the file's name and location.
            this.Text = "Kerbal Config Editor - " + openConfigDialog.FileName.Substring(0, 10) + "..." + openConfigDialog.FileName.Substring(openConfigDialog.FileName.LastIndexOf('\\') + 1);

            // Start opening the UI up for interaction again.
            toolStripProgressBar.Value = 100;
            DelayedProgressHide();
            UseWaitCursor = false;
        }

        /// <summary>
        /// Hides the progress indicators in the status bar after 1 second (1000 milliseconds).
        /// </summary>
        private async void DelayedProgressHide()
        {
            // Delay hiding the progress indicators for one second, and then hide.
            await Task.Delay(1000);
            toolStripProgressLabel.Visible = false;
            toolStripProgressBar.Visible = false;
        }

        /// <summary>
        /// Reports the progress gained by the file reader.
        /// </summary>
        /// <param name="progress">The progress, an integer value between 0 and 100, reported by the file reader.</param>
        private void ReportOpenProgress(int progress)
        {
            // Set the progress bar's value, ensuring it is clamped between 0 and 100.
            toolStripProgressBar.Value = progress.Clamp(0, 100);
        }

        /// <summary>
        /// Creates a unique string based off the current time, and an incremented number.
        /// </summary>
        /// <returns>A unique string based off the current time, and an incremented number.</returns>
        public static string GetUniqueString()
        {
            // Return this moment's binary string, pluse an incremented number, to string.
            return DateTime.Now.ToBinary().ToString() + cfgIncrement++.ToString();
        }
        #endregion
    }
}
