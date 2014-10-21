using UnityEngine;
using System.Collections;
using System.Xml;
using System.Collections.Generic;
using System;

public class Story : MonoBehaviour {
    XmlDocument XDoc = new XmlDocument() ;
    WorldTime WT = new WorldTime();
    List<Chapter> chapters;

    public void Start() {
        XDoc.Load( Application.dataPath + @"/Story.xml" );
        chapters = new List<Chapter>();
        ReadStory();
    }
    public void Update() {
        
    }

    private void ReadStory() {
        XmlNodeList root = XDoc.SelectSingleNode("Story").ChildNodes;

        foreach( XmlElement xn in root ) {
            Chapter temp = new Chapter();
            temp.SetChapterAndPhase(Int32.Parse(xn.GetAttribute("chapter")), 
                    Int32.Parse(xn.GetAttribute("phase")));
            
            foreach(XmlElement xnn in xn) {
                if( xnn.Name == "before" ) {
                    int tempDay = Int32.Parse(xnn.ChildNodes[0].InnerText);
                    List<int> tempEvent = new List<int>() ;
                    for( int i = 1; i < xnn.ChildNodes.Count; ++i ) {
                        tempEvent.Add(Int32.Parse(xnn.ChildNodes[i].InnerText));
                    }
                    temp.SetCondition(tempDay, tempEvent);
                }

                else {
                    List<ChapterNode> tempCHNode = new List<ChapterNode>() ;
                    foreach(XmlNode afterxn in xnn) {
                        string b = afterxn.ChildNodes[0].InnerText;
                        string l = afterxn.ChildNodes[1].InnerText;
                        string r = afterxn.ChildNodes[2].InnerText;
                        string d = afterxn.ChildNodes[3].InnerText;
                        tempCHNode.Add(new ChapterNode(b, l, r, d));
                    }

                    temp.SetPart(tempCHNode);
                }
            }

            chapters.Add(temp);
        }
    }

    private void StoryForward() {
        /*
         * LIst<int> QRecord = GameObject.Find("Gameobject").GetComponent("QuestManager").GetQuestRecord();
         * int nowDay = WT.CurrentDay ;
         * bool canPlay = false ;
         * for ( int i = 0 ; i < chapters.Count ; ++i ) {
         *     if ( chapters[i].GetDayCondition() == nowDay ) {
         *         List<int> eventList = chapters[i].GetEventCondition() ;
         *         for ( int j = 0 ; j < eventList.Count ; ++j ) {
         *             
         *         }
         *     }
         * }
         */

        
    }
    
}

public class Chapter {
    public int ChapterNO, Phase;
    private int beforeDay;
    private List<int> beforeEvent;
    private List<ChapterNode> afterEffect;

    public Chapter() {
        ChapterNO = Phase = beforeDay = 0;
        beforeEvent = new List<int>() ;
        afterEffect = new List<ChapterNode>();
    }

    public Chapter SetChapterAndPhase( int c, int p ) {
        ChapterNO = c;
        Phase = p;
        return this;
    }

    public Chapter SetCondition(int d, List<int> be) {
        beforeDay = d;
        beforeEvent = be;
        return this;
    }

    public Chapter SetPart(List<ChapterNode> ae) {
        afterEffect = ae;
        return this;
    }

    public List<int> GetEventCondition() {
        return beforeEvent;
    }

    public int GetDayCondition() {
        return beforeDay;
    }

    public List<ChapterNode> GetStoryInfo() {
        return afterEffect;
    }
}

public class ChapterNode {
     public Sprite Background ;
     public Sprite Left;
     public Sprite Right;
     public string Dialog ;

     public ChapterNode( string b, string l, string r, string d ) {
        Background = Resources.Load<Sprite>(b) ;
        Left = Resources.Load<Sprite>( l );
        Right = Resources.Load<Sprite>( r );
        Dialog = d ;
    }
}

