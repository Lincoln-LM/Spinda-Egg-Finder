using Spinda_Egg_Finder.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spinda_Egg_Finder
{
    public partial class Main : Form
    {
        BackgroundWorker backgroundWorker1 = new BackgroundWorker();
        DataTable source = new DataTable();
        uint c = 20;
        uint egg_pid = 0;
        List<uint> minivs;
        List<uint> maxivs; 
        List<uint> parentaivs;
        List<uint> parentbivs;
        string hiddenpowercheck;
        List<string> natures = new List<string> {
                "Hardy","Lonely","Brave","Adamant","Naughty",
                "Bold","Docile","Relaxed","Impish","Lax",
                "Timid","Hasty","Serious","Jolly","Naive",
                "Modest","Mild","Quiet","Bashful","Rash",
                "Calm","Gentle","Sassy","Careful","Quirky"};
        string shinystring = "No";
        bool all = false;
        

        public Main()
        {
            InitializeComponent();
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
        }

        private void searcherButton_Click(object sender, EventArgs e)
        {
            List<string> parentg = new List<string>() { parentagenderCombobox.Text, parentbgenderCombobox.Text };
            if (!(parentg.Contains("Male") & parentg.Contains("Female")) & !parentg.Contains("Ditto")) {
                MessageBox.Show("Parent gender incompatible.");
                return;
            }

            source.Rows.Clear();
            source.Columns.Clear();
            dataGridView1.Rows.Clear();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Visible)
                {
                    source.Columns.Add(column.Name);
                }
            }

            if (compatabilityCombobox.SelectedIndex == 1)
            {
                c = 50;
            }
            else if (compatabilityCombobox.SelectedIndex == 2)
            {
                c = 70;
            }

            if (shinyCheckbox.Checked)
            {
                shinystring = "Yes";
            }
            else
            {
                shinystring = "No";
            }

            if (allCheck.Checked)
            {
                all = true;
            }
            else
            {
                all = false;
            }

            hiddenpowercheck = (string)hpCombobox.SelectedItem;

            egg_pid = uint.Parse(pidTextbox.Text, System.Globalization.NumberStyles.HexNumber);

            minivs = new List<uint>() { (uint)HPMIN.Value, (uint)ATKMIN.Value, (uint)DEFMIN.Value, (uint)SPAMIN.Value, (uint)SPDMIN.Value, (uint)SPEMIN.Value };
            maxivs = new List<uint>() { (uint)HPMAX.Value, (uint)ATKMAX.Value, (uint)DEFMAX.Value, (uint)SPAMAX.Value, (uint)SPDMAX.Value, (uint)SPEMAX.Value };

            parentaivs = new List<uint>() { (uint)parentahp.Value, (uint)parentaatk.Value, (uint)parentadef.Value, (uint)parentaspa.Value, (uint)parentaspd.Value, (uint)parentaspd.Value };
            parentbivs = new List<uint>() { (uint)parentbhp.Value, (uint)parentbatk.Value, (uint)parentbdef.Value, (uint)parentbspa.Value, (uint)parentbspd.Value, (uint)parentbspd.Value };

            backgroundWorker1.RunWorkerAsync();
        }
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            source.Rows.Clear();
            uint pid1_high = ((egg_pid - 1 & 0xFFFF) << 16);
            uint pid2_low = (egg_pid >> 16);

            if (pid1_high != (((egg_pid - 1 & 0xFFFF) % 0xFFFE) << 16))
            {
                MessageBox.Show("PID is not possible by egg");
                return;
            }

            uint og_pid_high = pid1_high;
            uint og_pid_low = pid2_low;

            List<uint> seeds1 = new List<uint>();
            List<uint> seeds2 = new List<uint>();
            List<uint> pids1 = new List<uint>();
            List<uint> pids2 = new List<uint>();
            List<List<uint>> ivss = new List<List<uint>>();
            List<List<uint>> parents = new List<List<uint>>() { parentaivs, parentbivs };


            MessageBox.Show("Seed generation begun, do not click the search button again until the second set of seeds are generated or the program will crash.");
            while (seeds1.Count == 0)
            {
                List<uint> origin = recoverLower16BitsPID(pid1_high);
                foreach (uint seed in origin)
                {
                    PokeRNG go = new PokeRNG(seed);
                    if ((go.nextUShort() * 100 / 0xFFFF) < c)
                    {
                        seeds1.Add(seed);
                        pids1.Add(pid1_high);
                    }
                }
                if (seeds1.Count == 0)
                {
                    pid1_high = ((pid1_high) + 0x1);
                    if (pid1_high == og_pid_high)
                    {
                        MessageBox.Show("PID is not possible by egg");
                        return;
                    }
                }
            }
            MessageBox.Show("First set of seeds done. (PIDLow)");

            bool scondition = true;
            bool fcheck = true;

            while (scondition)
            {
                List<uint> origin = recoverLower16BitsPID(pid2_low);
                foreach (uint seed in origin)
                {
                    List<uint> ivs = generateUpper(seed, 0, parents);
                    bool check = true;
                    for (int i = 0; i < 6; i++)
                    {
                        if (ivs[i] > maxivs[i] || ivs[i] < minivs[i])
                        {
                            check = false;
                        }
                    }
                    if (hiddenpowercheck != "Any")
                    {
                        if (GetHPowerType(ivs) != hiddenpowercheck)
                        {
                            check = false;
                        }
                    }
                    if (check)
                    {
                        seeds2.Add(seed);
                        pids2.Add(pid2_low);
                        ivss.Add(ivs);
                    }
                }

                if (!all)
                {
                    scondition = seeds2.Count == 0;
                }
                else
                {
                    scondition = !(pid2_low == og_pid_low);
                }

                if (scondition | fcheck)
                {
                    fcheck = false;
                    pid2_low = pid2_low + 0x10000;
                    if (pid2_low == og_pid_low & seeds2.Count == 0)
                    {
                        MessageBox.Show("PID/IVs are not possible by egg");
                        return;
                    }
                }

                if (!all)
                {
                    scondition = seeds2.Count == 0;
                }
                else
                {
                    scondition = !(pid2_low == og_pid_low);
                }

            }
            MessageBox.Show("Second set of seeds done. (PIDHigh and IVs)");
            int y = 0;
            foreach (uint seed1 in seeds1)
            {
                int x = 0;
                foreach (uint seed2 in seeds2)
                {
                    List<uint> a = getInitial(seed1);
                    List<uint> b = getInitial(seed2);
                    List<uint> c = ivss[x];
                    source.Rows.Add(a[0].ToString("X4"), a[1], pids1[y].ToString("X8"), b[0].ToString("X4"), b[1], pids2[x].ToString("X8"), egg_pid.ToString("X8"), "", natures[(int)(egg_pid % 25)], egg_pid & 1, c[0], c[1], c[2], c[3], c[4], c[5], GetHPowerType(c), GetHPowerDamage(c));
                    x++;
                }
                y += 1;
            }

        }

        private Bitmap pidtospinda(uint piduint, string shiny)
        {
            int spot1x, spot1y, spot2x, spot2y, spot3x, spot3y, spot4x, spot4y;
            string pid, pid1, pid2, pid3, pid4, pid5, pid6, pid7, pid8;


            pid = piduint.ToString("X8");
            pid1 = pid.Substring(0, 1);
            pid2 = pid.Substring(1, 1);
            pid3 = pid.Substring(2, 1);
            pid4 = pid.Substring(3, 1);
            pid5 = pid.Substring(4, 1);
            pid6 = pid.Substring(5, 1);
            pid7 = pid.Substring(6, 1);
            pid8 = pid.Substring(7, 1);

            spot1x = int.Parse(pid8, System.Globalization.NumberStyles.HexNumber);
            spot1y = int.Parse(pid7, System.Globalization.NumberStyles.HexNumber);
            spot2x = int.Parse(pid6, System.Globalization.NumberStyles.HexNumber);
            spot2y = int.Parse(pid5, System.Globalization.NumberStyles.HexNumber);
            spot3x = int.Parse(pid4, System.Globalization.NumberStyles.HexNumber);
            spot3y = int.Parse(pid3, System.Globalization.NumberStyles.HexNumber);
            spot4x = int.Parse(pid2, System.Globalization.NumberStyles.HexNumber);
            spot4y = int.Parse(pid1, System.Globalization.NumberStyles.HexNumber);

            string shinyval;
            if (shiny == "Yes")
            {
                shinyval = "shiny";
            }
            else
            {
                shinyval = "";
            }
            var bitmap = new Bitmap(104, 118);
            using (var g = Graphics.FromImage(bitmap))
            {
                ResourceManager rm = Resources.ResourceManager;

                var bmp1 = (Bitmap)rm.GetObject("spindapog" + shinyval);
                var bmp2 = (Bitmap)rm.GetObject("spot1" + shinyval);
                var bmp3 = (Bitmap)rm.GetObject("spot2" + shinyval);
                var bmp4 = (Bitmap)rm.GetObject("spot3" + shinyval);
                var bmp5 = (Bitmap)rm.GetObject("spot4" + shinyval);
                g.DrawImage(bmp1, 0, 0, 104, 118);
                g.DrawImage(bmp2, spot1x * 2, spot1y * 2, 104, 118);
                g.DrawImage(bmp3, spot2x * 2, spot2y * 2, 104, 118);
                g.DrawImage(bmp4, spot3x * 2, spot3y * 2, 104, 118);
                g.DrawImage(bmp5, spot4x * 2, spot4y * 2, 104, 118);
                if (overlayCheckbox.Checked)
                {
                    var bmp6 = (Bitmap)rm.GetObject("spindaoverlay" + shinyval);
                    g.DrawImage(bmp6, 0, 0, 104, 118);
                }

                return bitmap;
            }

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach (DataRow r in source.Rows)
            {
                object[] ria = r.ItemArray;
                ria[7] = pidtospinda(egg_pid, shinystring);
                dataGridView1.Rows.Add(ria);
            }
        }

        private List<uint> getInitial(uint seed)
        {
            uint advances = 0;
            PokeRNGR rng = new PokeRNGR(seed);
            while (rng.seed > 0xFFFF)
            {
                rng.nextUInt();
                advances += 1;
            }
            return new List<uint> {rng.seed, advances};
        }

        public List<string> hpowertypes = new List<string> { "Fighting", "Flying", "Poison",
                                                             "Ground", "Rock", "Bug",
                                                             "Ghost", "Steel", "Fire",
                                                             "Water", "Grass", "Electric",
                                                             "Psychic", "Ice", "Dragon",
                                                                        "Dark" };
        private string GetHPowerType(List<uint> ivs)
        {
            uint a, b, c, d, e, f;

            a = ivs[0] & 1;
            b = ivs[1] & 1;
            c = ivs[2] & 1;
            d = ivs[5] & 1;
            e = ivs[3] & 1;
            f = ivs[4] & 1;

            return hpowertypes[(int)(((a + 2 * b + 4 * c + 8 * d + 16 * e + 32 * f) * 15) / 63)];
        }
        private uint GetHPowerDamage(List<uint> ivs)
        {
            uint u, v, w, x, y, z;

            u = (ivs[0] >> 1) & 1;
            v = (ivs[1] >> 1) & 1;
            w = (ivs[2] >> 1) & 1;
            x = (ivs[5] >> 1) & 1;
            y = (ivs[3] >> 1) & 1;
            z = (ivs[4] >> 1) & 1;

            return ((u + 2 * v + 4 * w + 8 * x + 16 * y + 32 * z) * 40) / 63 + 30;

        }

        private uint generateLower(uint seed, uint compatability)
        {
            PokeRNG go = new PokeRNG(seed);
            if ((go.nextUShort() * 100 / 0xFFFF) < compatability)
            {
                uint pid = (ushort)((go.nextUShort() % 0xFFFE) + 1);
                return pid;
            }
            return 0x10000;
        }

        private List<uint> generateUpper(uint seed, uint lower, List<List<uint>> parents)
        {
            PokeRNG go = new PokeRNG(seed);

            uint pid = go.nextUShort();

            go.nextUInt();
            uint iv1 = go.nextUShort();
            uint iv2 = go.nextUShort();
            List<uint> ivs = getIVs(iv1,iv2);


            go.nextUInt();
            uint inh1 = go.nextUShort();
            uint inh2 = go.nextUShort();
            uint inh3 = go.nextUShort();
            List<uint> inh = new List<uint>() { inh1, inh2, inh3 };

            uint par1 = go.nextUShort();
            uint par2 = go.nextUShort();
            uint par3 = go.nextUShort();
            List<uint> par = new List<uint>() { par1, par2, par3 };

            ivs = setInheritance(ivs, inh, par, parents);
            return ivs;
        }

        private List<uint> getIVs(uint iv1, uint iv2)
        {
            uint hp = iv1 & 0x1f;
            uint atk = (iv1 >> 5) & 0x1f;
            uint defense = (iv1 >> 10) & 0x1f;
            uint spa = (iv2 >> 5) & 0x1f;
            uint spd = (iv2 >> 10) & 0x1f;
            uint spe = iv2 & 0x1f;
            return new List<uint> { hp, atk, defense, spa, spd, spe };
        }

        private List<uint> setInheritance(List<uint> ivs, List<uint> inh, List<uint> par, List<List<uint>> parents)
        {
            List<int> available = new List<int> { 0, 1, 2, 3, 4, 5 };
            for (int i = 0; i < 3; i++)
            {
                int stat = available[(int)inh[i] % (6 - i)];
                int parent = (int)par[i] & 1;
                int s = stat;
                if (s == 3)
                {
                    s = 5;
                }
                else if (s > 3)
                {
                    s -= 1;
                }

                ivs[s] = parents[parent][s];

                int j = stat;
                while (j < 5 - i)
                {
                    available[j] = available[j + 1];
                    j += 1;
                }

            }
            return ivs;
        }

        private List<uint> recoverLower16BitsPID(uint pid)
        {
            uint add;
            uint k;
            uint mult;
            byte[] low = new byte[0x10000];
            bool[] flags = new bool[0x10000];


            k = 0xC64E6D00; // Mult << 8
            mult = 0x41c64e6d; // pokerng constant
            add = 0x6073; // pokerng constant
            uint count = 0;
            foreach (byte element in low)
            {
                low[count] = 0;
                count++;
            }
            count = 0;
            foreach (bool element in flags)
            {
                flags[count] = false;
                count++;
            }
            for (short i = 0; i < 256; i++)
            {
                uint right = (uint)(mult * i + add);
                ushort val = (ushort)(right >> 16);
                flags[val] = true;
                low[val--] = (byte)(i);
                flags[val] = true;
                low[val] = (byte)(i);
            }
            List<uint> origin = new List<uint>();

            uint first = pid << 16;
            uint second = pid & 0xFFFF0000;
            uint search = second - first * mult;

            for (uint i = 0; i < 256; i++, search -= k)
            {
                if (flags[search >> 16])
                {
                    uint test = first | (i << 8) | low[search >> 16];
                    if (((test * mult + add) & 0xffff0000) == second)
                    {
                        PokeRNGR rng = new PokeRNGR(test);
                        uint seed = rng.nextUInt();
                        origin.Add(seed);
                    }
                }
            }
            return origin;
        }

        private void painterButton_Click(object sender, EventArgs e)
        {
            using (Form2 form2 = new Form2())
            {
                if (form2.ShowDialog() == DialogResult.OK)
                {
                    pidTextbox.Text = form2.TheValue;
                }
            }
        }
    }
}