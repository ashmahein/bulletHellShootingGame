using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BHSTG
{
    public class ScriptReader
    {
        public int level { get; set; }
        public int startTimer { get; set; }
        public int endTimer { get; set; }
        public int xStart { get; set; }
        public int yStart { get; set; }
        public int xEnd { get; set; }
        public int yEnd { get; set; }
        public int enemyAmount { get; set; }
        public int spawnInterval { get; set; }
        public String enemySprite { get; set; }
        public String enemyBullets { get; set; }
        public String enemyMovementType { get; set; }
        public String enemyShootType { get; set; }

        public ScriptReader()
        {
            LoadScriptInfo();
        }

        public List<Wave> waveList = new List<Wave>();

        public void LoadScriptInfo()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("BHSGScript.xml");
            XmlNodeList xmlNode;

            xmlNode = doc.GetElementsByTagName("wave");
            string enemySprite = "";

            for (int i = 0; i < xmlNode.Count; i++)
            {
                Wave newWave = new Wave();
                newWave.level = Convert.ToInt32(xmlNode[i].ChildNodes.Item(0).InnerText);
                newWave.startTimer = Convert.ToInt32(xmlNode[i].ChildNodes.Item(1).InnerText);
                newWave.endTimer = Convert.ToInt32(xmlNode[i].ChildNodes.Item(2).InnerText);
                enemySprite = xmlNode[i].ChildNodes.Item(3).InnerText.ToString();
                enemySprite = enemySprite.Substring(1, enemySprite.Length -2);
                newWave.enemyType = enemySprite;
                newWave.enemyAmount = Convert.ToInt32(xmlNode[i].ChildNodes.Item(4).InnerText);
                newWave.spawnInterval = Convert.ToInt32(xmlNode[i].ChildNodes.Item(5).InnerText);
                newWave.xStart = Convert.ToInt32(xmlNode[i].ChildNodes.Item(6).InnerText);
                newWave.yStart = Convert.ToInt32(xmlNode[i].ChildNodes.Item(7).InnerText);
                newWave.xEnd = Convert.ToInt32(xmlNode[i].ChildNodes.Item(8).InnerText);
                newWave.yEnd = Convert.ToInt32(xmlNode[i].ChildNodes.Item(9).InnerText);

                enemySprite = xmlNode[i].ChildNodes.Item(10).InnerText.ToString();
                enemySprite = enemySprite.Substring(1, enemySprite.Length - 2);
                newWave.enemyBullets = enemySprite;

                enemySprite = xmlNode[i].ChildNodes.Item(11).InnerText.ToString();
                enemySprite = enemySprite.Substring(1, enemySprite.Length - 2);
                newWave.enemyMovementType = enemySprite;

                enemySprite = xmlNode[i].ChildNodes.Item(12).InnerText.ToString();
                enemySprite = enemySprite.Substring(1, enemySprite.Length - 2);
                newWave.enemyShootType = enemySprite;

                enemySprite = xmlNode[i].ChildNodes.Item(13).InnerText.ToString();
                enemySprite = enemySprite.Substring(1, enemySprite.Length - 2);
                newWave.enemySprite = enemySprite;
                waveList.Add(newWave);

            }
        }
    }
}
