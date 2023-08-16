using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;

namespace BasicFacebookFeatures
{
    internal class DummyData

    {
        private string m_FileName;
        public string[,] DataMatrix { get; set; }
        public DummyFriend[] DummyFriendsList { get; set; }
        public DummyData()
        {
            string file = "DummyDataFriends.txt";
            string RunningPath = AppDomain.CurrentDomain.BaseDirectory;
            this.m_FileName = string.Format("{0}Resources\\{1}", Path.GetFullPath(Path.Combine(RunningPath, @"..\..\")) , file);
            DataMatrix = new string[File.ReadAllLines(m_FileName).Length, 9];
            DummyFriendsList = new DummyFriend[10];
            fillDataMatrix();
            createFriends();
        }
        private void fillDataMatrix()
        {
            int countLines = 0;
            string[] allLines = File.ReadAllLines(m_FileName);
            foreach (string line in allLines)
            {
                string[] splittedLine = line.Split(',');
                for (int j = 0; j < 9; j++)
                {
                    DataMatrix[countLines, j] = splittedLine[j];
                }
                countLines++;
            }
        }
        private void createFriends()
        {
            for (int i = 0; i < 10; i++)
            {
                DummyFriend dummyFriend = new DummyFriend(DataMatrix[i, 0], DataMatrix[i, 1], DataMatrix[i, 2],
                    DataMatrix[i, 3], DataMatrix[i, 4], DataMatrix[i, 5], DataMatrix[i, 6], double.Parse(DataMatrix[i, 7]),
                    double.Parse(DataMatrix[i, 8]));
                DummyFriendsList[i] = dummyFriend;
            }
        }
    }
}
