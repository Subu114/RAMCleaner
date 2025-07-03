using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace RAMCleaner
{
    public partial class Form1 : Form
    {
        private int sortColumn = -1;
        private bool sortAscending = true;

        public Form1()
        {
            InitializeComponent();
            LoadProcesses();
            LoadFavorites();
        }
        private void LoadProcesses()
        {
            imageListProcess.Images.Clear();
            listViewProcesses.Items.Clear();

            Process[] processes = Process.GetProcesses();

            foreach (Process proc in processes)
            {
                try
                {
                    string name = proc.ProcessName;

                    if (protectedProcesses.Contains(name, StringComparer.OrdinalIgnoreCase))
                        continue;

                    int pid = proc.Id;
                    double memoryMb = proc.PrivateMemorySize64 / (1024.0 * 1024.0);

                    string iconKey = name;

                    if (!imageListProcess.Images.ContainsKey(iconKey))
                    {
                        try
                        {
                            Icon icon = Icon.ExtractAssociatedIcon(proc.MainModule.FileName);
                            imageListProcess.Images.Add(iconKey, icon);
                        }
                        catch
                        {
                            // Add a default icon if failed
                            imageListProcess.Images.Add(iconKey, SystemIcons.Application);
                        }
                    }

                    ListViewItem item = new ListViewItem(name);
                    item.ImageKey = iconKey;
                    item.SubItems.Add(pid.ToString());
                    item.SubItems.Add(memoryMb.ToString("F2"));

                    listViewProcesses.Items.Add(item);
                }
                catch
                {
                    // skip errors
                }
            }
        }

        private readonly string favoritesFile = "favorites.txt";

        private void LoadFavorites()
        {
            listViewFavourites.Items.Clear();

            if (!File.Exists(favoritesFile)) return;

            string[] favorites = File.ReadAllLines(favoritesFile);

            foreach (string fav in favorites)
            {
                if (!string.IsNullOrWhiteSpace(fav))
                {
                    listViewFavourites.Items.Add(new ListViewItem(fav.Trim()));
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadProcesses();
        }

        private readonly string[] protectedProcesses = new string[]
        {
            "System",
            "Idle",
            "svchost",
            "wininit",
            "winlogon",
            "csrss",
            "lsass",
            "services",
            "explorer", // You may allow this if needed
            "dwm"
        };

        private void btnKill_Click(object sender, EventArgs e)
        {
            if (listViewProcesses.SelectedItems.Count > 0)
            {
                string selectedPidText = listViewProcesses.SelectedItems[0].SubItems[1].Text;

                if (int.TryParse(selectedPidText, out int pid))
                {
                    try
                    {
                        Process proc = Process.GetProcessById(pid);
                        proc.Kill();
                        MessageBox.Show($"Killed process {proc.ProcessName} (PID: {pid})", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadProcesses(); // Refresh the list after killing
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a process first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            LoadFavorites();
        }

        private void btnAddFavourite_Click(object sender, EventArgs e)
        {
            if (listViewProcesses.SelectedItems.Count > 0)
            {
                string processName = listViewProcesses.SelectedItems[0].Text;

                // Save process name to favorites file if not already present
                if (!File.Exists(favoritesFile))
                {
                    File.WriteAllText(favoritesFile, processName + Environment.NewLine);
                    MessageBox.Show($"{processName} added to favorites.");
                }
                else
                {
                    var existing = File.ReadAllLines(favoritesFile);
                    if (!existing.Contains(processName, StringComparer.OrdinalIgnoreCase))
                    {
                        File.AppendAllText(favoritesFile, processName + Environment.NewLine);
                    }
                    else
                    {
                        MessageBox.Show($"{processName} is already in favorites.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Select a process to add to favorites.");
            }
            LoadFavorites();
        }

        private void btnKillFavorites_Click(object sender, EventArgs e)
        {
            if (!File.Exists(favoritesFile))
            {
                MessageBox.Show("Favorites list is empty.");
                return;
            }

            var favorites = File.ReadAllLines(favoritesFile);

            int killCount = 0;

            foreach (string favName in favorites)
            {
                var matching = Process.GetProcessesByName(favName);

                foreach (var proc in matching)
                {
                    try
                    {
                        proc.Kill();
                        killCount++;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to kill {proc.ProcessName} (PID: {proc.Id})\n{ex.Message}");
                    }
                }
            }

            MessageBox.Show($"Killed {killCount} favorite processes.");
            LoadProcesses(); // Refresh list
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonRemoveFavourite_Click(object sender, EventArgs e)
        {
            if (listViewFavourites.SelectedItems.Count > 0)
            {
                string toRemove = listViewFavourites.SelectedItems[0].Text;

                if (File.Exists(favoritesFile))
                {
                    var lines = File.ReadAllLines(favoritesFile).ToList();
                    lines.RemoveAll(line => line.Equals(toRemove, StringComparison.OrdinalIgnoreCase));
                    File.WriteAllLines(favoritesFile, lines);


                    LoadFavorites();
                }
            }
            else
            {
                MessageBox.Show("Select a favorite to remove.");
            }
        }

        private void listViewProcesses_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == sortColumn)
            {
                // Toggle sort direction
                sortAscending = !sortAscending;
            }
            else
            {
                sortColumn = e.Column;
                sortAscending = true;
            }

            listViewProcesses.ListViewItemSorter = new ListViewItemComparer(e.Column, sortAscending);
        }

        private void listViewProcesses_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listViewProcesses.SelectedItems.Count > 0)
            {
                string processName = listViewProcesses.SelectedItems[0].Text;

                if (!File.Exists(favoritesFile))
                {
                    File.WriteAllText(favoritesFile, processName + Environment.NewLine);
                }
                else
                {
                    var existing = File.ReadAllLines(favoritesFile);
                    if (!existing.Contains(processName, StringComparer.OrdinalIgnoreCase))
                    {
                        File.AppendAllText(favoritesFile, processName + Environment.NewLine);
                    }
                    else
                    {
                        MessageBox.Show($"{processName} is already in favorites.");
                        return;
                    }
                }

                LoadFavorites();
            }
        }

        private void listViewFavourites_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listViewFavourites.SelectedItems.Count > 0)
            {
                string toRemove = listViewFavourites.SelectedItems[0].Text;

                if (File.Exists(favoritesFile))
                {
                    var lines = File.ReadAllLines(favoritesFile).ToList();
                    lines.RemoveAll(line => line.Equals(toRemove, StringComparison.OrdinalIgnoreCase));
                    File.WriteAllLines(favoritesFile, lines);

                    LoadFavorites();
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }
    }

    class ListViewItemComparer : System.Collections.IComparer
    {
        private int col;
        private bool ascending;

        public ListViewItemComparer(int column, bool ascendingOrder)
        {
            col = column;
            ascending = ascendingOrder;
        }

        public int Compare(object x, object y)
        {
            string a = ((ListViewItem)x).SubItems[col].Text;
            string b = ((ListViewItem)y).SubItems[col].Text;

            // Try to compare as numbers (like PID or Memory)
            if (double.TryParse(a, out double da) && double.TryParse(b, out double db))
            {
                return ascending ? da.CompareTo(db) : db.CompareTo(da);
            }

            // Compare as strings
            return ascending ? string.Compare(a, b) : string.Compare(b, a);
        }
    }

}
