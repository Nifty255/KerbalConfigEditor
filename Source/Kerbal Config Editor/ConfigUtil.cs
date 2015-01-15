using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.ComponentModel;

namespace KerbalConfigEditor
{
    public static class ConfigUtil
    {
        // Used to evaluate whether a given string is alphanumeric, including dashes and underscores.
        public static Regex alphanumeric = new Regex("^[A-Za-z0-9_-]*$");

        #region Node Saving
        // Node Saving

        /// <summary>
        /// Saves the provided ConfigNode to the specified file path, overwriting if requested.
        /// </summary>
        /// <param name="node">The ConfigNode to save to file.</param>
        /// <param name="fullFilePath">The file path.</param>
        /// <returns>True if the save was successful.</returns>
        public static bool SaveConfigFile(ConfigNode node, string fullFilePath)
        {
            // Try to save the file. If for some reason it can't, return false.
            try
            {
                // Convert the provided ConfigNode into an array of strings to write, and then write them.
                string[] toWrite = ConvertNodeToLines(node, -1).ToArray();
                File.WriteAllLines(fullFilePath, toWrite);
            }
            catch
            {
                return false;
            }
            
            // At this point, the write was successful. Return true.
            return true;
        }

        /// <summary>
        /// Converts the provided ConfigNode into a list of strings. This function recurses through all child nodes, converting them as well.
        /// </summary>
        /// <param name="node">The ConfigNode to convert and recurse through.</param>
        /// <param name="indent">The number of indents, represented as multiples of 4 spaces, to convert with.</param>
        /// <returns>A list of strings converted from the provided ConfigNode.</returns>
        public static List<string> ConvertNodeToLines(ConfigNode node, int indent)
        {
            // Create a list to return.
            List<string> toRet = new List<string>();

            // Generate the string used for indentions.
            string indentString = "";
            for (int i = 0; i < indent; i++)
            {
                indentString += "    ";
            }
            
            // If this isn't the root node,
            if (node.name != "")
            {
                // Write the node's name and then an opening bracket.
                toRet.Add(indentString + node.name);
                toRet.Add(indentString + "{");
            }

            // Foreach value in the current node, write.
            foreach (ConfigNode.Value v in node.values)
            {
                toRet.Add(indentString + "    " + v.name + " = " + v.value);
            }

            // Foreach node in the current node, write.
            foreach (ConfigNode n in node.nodes)
            {
                toRet.AddRange(ConvertNodeToLines(n, indent + 1));
            }

            if (node.name != "")
            {
                // Add the closing bracket, finishing the current node.
                toRet.Add(indentString + "}");
            }

            return toRet;
        }
        #endregion

        #region Node Loading
        // Node Loading

        /// <summary>
        /// Loads the config file located at the specified file path.
        /// </summary>
        /// <param name="fullFilePath">The path to the config file.</param>
        /// <param name="worker">The BackgroundWorker used to perform this operation.</param>
        /// <returns>The root ConfigNode loaded from the file.</returns>
        public static ConfigNode LoadConfigFile(string fullFilePath, BackgroundWorker worker)
        {
            // Read the file into a string array.
            string[] linesFromFile = File.ReadAllLines(fullFilePath);

            // Is the file empty?
            if (linesFromFile.Length == 0 || (linesFromFile.Length == 1 && linesFromFile[0] == ""))
            {
                throw new FormatException("The file is empty!");
            }

            // Parse the array of read lines.
            return ParseConfigLines(linesFromFile, worker, 0, linesFromFile.Length);
        }

        /// <summary>
        /// Parses the provided array of strings into a ConfigNode. This method recurses through all found child nodes.
        /// </summary>
        /// <param name="configLines">The array of strings to parse.</param>
        /// <param name="worker">The BackgroundWorker used to perform this operation.</param>
        /// <param name="current">The current position in the original array given.</param>
        /// <param name="total">The total length of the original array given.</param>
        /// <returns>The ConfigNode parsed from the current array, complete with any parsed child nodes.</returns>
        public static ConfigNode ParseConfigLines(string[] configLines, BackgroundWorker worker, int current, int total)
        {
            // Create a new ConfigNode and assign a new unique string ID.
            ConfigNode root = new ConfigNode();
            root.id = ProgramForm.GetUniqueString();

            // Iterate through the array of strings.
            for (int i = 0; i < configLines.Length; i++)
            {
                // If an opening bracket is found,
                if (configLines[i].Trim() == "{")
                {
                    // We might have found a node. See if there is a name on the previous line.
                    string nodeName = configLines[i - 1].Trim();
                    if (!nodeName.Contains(' '))
                    {
                        // The node has a name so far. Look for closing bracket.
                        int levels = 0;
                        int closingLine = -1;
                        for (int j = i + 1; j < configLines.Length; j++)
                        {
                            // If another opening bracket is found before a closing bracket, indicate we went up a level.
                            if (configLines[j].Trim() == "{")
                            {
                                levels++;
                            }
                            // Otherwise, if a closing bracket is found,
                            else if (configLines[j].Trim() == "}")
                            {
                                // If we are still above level zero, then we have found a child bracket's closing bracket, and not our own.
                                // Thus, we indicate we simply went down a level and keep looking.
                                if (levels > 0)
                                {
                                    levels--;
                                }
                                // If we are on level zero when we found this bracket, then we have found the right bracket. Store the line at which we close.
                                else
                                {
                                    closingLine = j;
                                }
                            }
                        }

                        // If the closing line wasn't found, then there's a problem with the file.
                        if (closingLine == -1)
                        {
                            // Throw a FormatException, which will be handled by the method given to the BackgroundWorker's TaskCompeted event subscriber.
                            throw new FormatException("Line " + (current + i).ToString() + ": Node name \"" + nodeName + "\" does not have a matching closing bracket!");
                        }

                        // Otherwise, we can begin parsing the found child node and then applying the name found to it.
                        ConfigNode child = ParseConfigLines(configLines.SubArray(i + 1, closingLine - i - 1), worker, i + current, total);
                        child.name = nodeName;

                        // Add the parsed child node to the current node.
                        root.AddNode(child);

                        // Report progress so the UI shows work is being done.
                        worker.ReportProgress((current + closingLine) * 100 / total);

                        // Remove the node's text from the file so we don't accidentally parse a child node's values into the current node.
                        for (int j = i - 1; j < closingLine + 1; j++)
                        {
                            configLines[j] = "";
                        }
                    }
                    // If the node's name isn't a proper name, there's a problem with the file.
                    else
                    {
                        // Throw a FormatException, which will be handled by the method given to the BackgroundWorker's TaskCompeted event subscriber.
                        throw new FormatException("Line " + (current + i + 1).ToString() + ": Node name \"" + nodeName + "\" has a space!");
                    }
                }
            }

            // Now that child nodes are taken care of and removed from the current array, iterate through looking for values.
            for (int i = 0; i < configLines.Length; i++)
            {
                // If the current line contains an equals sign, but doesn't begin with comment slashes,
                if (configLines[i].Contains(" = ") && configLines[i].Trim().IndexOf("//") != 0)
                {
                    // A value has been found! Get the name of the value and trim it.
                    string key = configLines[i].Substring(0, configLines[i].IndexOf('='));
                    key = key.Trim();

                    // Now get the value of the value and trim it.
                    string val = configLines[i].Substring(configLines[i].IndexOf('=') + 1);
                    val = val.Trim();

                    // If the name is proper, then we can add the value to the current node.
                    if (alphanumeric.IsMatch(key) && val.Length > 0)
                    {
                        root.AddValue(key, val);
                    }
                }
            }

            // We're finished parsing the current node. Return it.
            return root;
        }
        #endregion

        #region Node Finding
        // Node Finding

        /// <summary>
        /// Gets the parent ConfigNode of the provided ConfigNode. This function recurses through all child nodes until the parent is found, or until all iterations are complete.
        /// </summary>
        /// <param name="child">The ConfigNode to get the parent of.</param>
        /// <param name="toCheck">The current node we should check inside.</param>
        /// <returns>The parent ConfigNode if found, or null if not found.</returns>
        public static ConfigNode GetParentOfNode(ConfigNode child, ConfigNode toCheck)
        {
            // If the current node we're checking in has a node with the same ID, return this node, since it is the parent.
            if (toCheck.HasNodeID(child.id))
            {
                return toCheck;
            }

            // Otherwise, iterate through all child nodes and check them for parenthood.
            foreach (ConfigNode n in toCheck.nodes)
            {
                // If this node, or any of its children, are the parent, it will be returned, otherwise, null will be returned.
                ConfigNode parent = GetParentOfNode(child, n);

                // If a parent was returned, return it again, until the first call of this function returns the node to the original caller.
                if (parent != null)
                {
                    return parent;
                }
            }

            // If this node nor any of its children are the parent, return null.
            return null;
        }

        /// <summary>
        /// Gets a ConfigNode matching the provided ID. This function recurses through all child nodes until a match is found, or until all iterations are complete.
        /// </summary>
        /// <param name="current">The current ConfigNode to check for a matching ID.</param>
        /// <param name="id">The ID to match.</param>
        /// <returns>The matching ConfigNode if found, or null if not found.</returns>
        public static ConfigNode GetNodeById(ConfigNode current, string id)
        {
            // If this node's ID matches, return it.
            if (current.id == id)
            {
                return current;
            }

            // Otherwise, recurse through any children and check them.
            foreach (ConfigNode n in current.nodes)
            {
                // If this node, or any of its children, has a matching ID, it will be returned, otherwise, null will be returned.
                ConfigNode t = GetNodeById(n, id);

                // If a match was returned, return it again, until the first call of this function returns the node to the original caller.
                if (t != null)
                {
                    return t;
                }
            }

            // If this node nor any of its children have a matching ID, return null.
            return null;
        }
        #endregion

        #region Extension Stuff
        // Extension Stuff

        /// <summary>
        /// Extension method. Returns a sub-array of objects of type T.
        /// </summary>
        /// <typeparam name="T">The type of the data array.</typeparam>
        /// <param name="data">The array of type T.</param>
        /// <param name="index">The starting index from which to create the sub-array.</param>
        /// <param name="length">The length of the sub-array.</param>
        /// <returns>Returns a sub-array of objects of type T.</returns>
        public static T[] SubArray<T>(this T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }

        /// <summary>
        /// Extension method. Clamps the value of type T between min and max.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="val">The value of type T.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>Returns a clamped value of type T between min and max.</returns>
        public static T Clamp<T>(this T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0) return min;
            else if (val.CompareTo(max) > 0) return max;
            else return val;
        }
        #endregion
    }
}
