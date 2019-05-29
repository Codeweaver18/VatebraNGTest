using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Vatebra.DataAccessLayer.Entities
{
 
    

    public class Team : BaseEntity
    {
        public string TeamName { get; set; }
        public string TeamDescription { get; set; }
      
    }
    public class Footballers : BaseEntity
    {
        [ForeignKey("TeamId")]
        public virtual Team Team { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string PlayerPosition { get; set; }
        public DateTime DateJoined { get; set; }
    }

    public class Match : BaseEntity
    {
        public string MatchName { get; set; }
        public string MatchVenue { get; set; }
        public DateTime MatchDate { get; set; }
    

    }

    //MatchGoals
    //*******************
    //MatchId, ScorerId, GoalScoreDescription {penalty or anything
    //}
    public class MatchGoals : BaseEntity
    {

        [ForeignKey("FootballersId")]
        public virtual Footballers Footballers { get; set; }

        [ForeignKey("MatchId")]
        public virtual Match  Match{ get; set; }

     
        public string goalDescription{ get; set; }
    }

}
