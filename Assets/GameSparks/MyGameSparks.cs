#pragma warning disable 612,618
#pragma warning disable 0114
#pragma warning disable 0108

using System;
using System.Collections.Generic;
using GameSparks.Core;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;

//THIS FILE IS AUTO GENERATED, DO NOT MODIFY!!
//THIS FILE IS AUTO GENERATED, DO NOT MODIFY!!
//THIS FILE IS AUTO GENERATED, DO NOT MODIFY!!

namespace GameSparks.Api.Requests{
		public class LogEventRequest_LEADERBOARD_SCORER : GSTypedRequest<LogEventRequest_LEADERBOARD_SCORER, LogEventResponse>
	{
	
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogEventResponse (response);
		}
		
		public LogEventRequest_LEADERBOARD_SCORER() : base("LogEventRequest"){
			request.AddString("eventKey", "LEADERBOARD_SCORER");
		}
		public LogEventRequest_LEADERBOARD_SCORER Set_SCORER( long value )
		{
			request.AddNumber("SCORER", value);
			return this;
		}			
	}
	
	public class LogChallengeEventRequest_LEADERBOARD_SCORER : GSTypedRequest<LogChallengeEventRequest_LEADERBOARD_SCORER, LogChallengeEventResponse>
	{
		public LogChallengeEventRequest_LEADERBOARD_SCORER() : base("LogChallengeEventRequest"){
			request.AddString("eventKey", "LEADERBOARD_SCORER");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogChallengeEventResponse (response);
		}
		
		/// <summary>
		/// The challenge ID instance to target
		/// </summary>
		public LogChallengeEventRequest_LEADERBOARD_SCORER SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
		public LogChallengeEventRequest_LEADERBOARD_SCORER Set_SCORER( long value )
		{
			request.AddNumber("SCORER", value);
			return this;
		}			
	}
	
}
	
	
	
namespace GameSparks.Api.Requests{
	
	public class LeaderboardDataRequest_HIGH_SCORE : GSTypedRequest<LeaderboardDataRequest_HIGH_SCORE,LeaderboardDataResponse_HIGH_SCORE>
	{
		public LeaderboardDataRequest_HIGH_SCORE() : base("LeaderboardDataRequest"){
			request.AddString("leaderboardShortCode", "HIGH_SCORE");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LeaderboardDataResponse_HIGH_SCORE (response);
		}		
		
		/// <summary>
		/// The challenge instance to get the leaderboard data for
		/// </summary>
		public LeaderboardDataRequest_HIGH_SCORE SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
		/// <summary>
		/// The number of items to return in a page (default=50)
		/// </summary>
		public LeaderboardDataRequest_HIGH_SCORE SetEntryCount( long entryCount )
		{
			request.AddNumber("entryCount", entryCount);
			return this;
		}
		/// <summary>
		/// A friend id or an array of friend ids to use instead of the player's social friends
		/// </summary>
		public LeaderboardDataRequest_HIGH_SCORE SetFriendIds( List<string> friendIds )
		{
			request.AddStringList("friendIds", friendIds);
			return this;
		}
		/// <summary>
		/// Number of entries to include from head of the list
		/// </summary>
		public LeaderboardDataRequest_HIGH_SCORE SetIncludeFirst( long includeFirst )
		{
			request.AddNumber("includeFirst", includeFirst);
			return this;
		}
		/// <summary>
		/// Number of entries to include from tail of the list
		/// </summary>
		public LeaderboardDataRequest_HIGH_SCORE SetIncludeLast( long includeLast )
		{
			request.AddNumber("includeLast", includeLast);
			return this;
		}
		
		/// <summary>
		/// The offset into the set of leaderboards returned
		/// </summary>
		public LeaderboardDataRequest_HIGH_SCORE SetOffset( long offset )
		{
			request.AddNumber("offset", offset);
			return this;
		}
		/// <summary>
		/// If True returns a leaderboard of the player's social friends
		/// </summary>
		public LeaderboardDataRequest_HIGH_SCORE SetSocial( bool social )
		{
			request.AddBoolean("social", social);
			return this;
		}
		/// <summary>
		/// The IDs of the teams you are interested in
		/// </summary>
		public LeaderboardDataRequest_HIGH_SCORE SetTeamIds( List<string> teamIds )
		{
			request.AddStringList("teamIds", teamIds);
			return this;
		}
		/// <summary>
		/// The type of team you are interested in
		/// </summary>
		public LeaderboardDataRequest_HIGH_SCORE SetTeamTypes( List<string> teamTypes )
		{
			request.AddStringList("teamTypes", teamTypes);
			return this;
		}
		
	}

	public class AroundMeLeaderboardRequest_HIGH_SCORE : GSTypedRequest<AroundMeLeaderboardRequest_HIGH_SCORE,AroundMeLeaderboardResponse_HIGH_SCORE>
	{
		public AroundMeLeaderboardRequest_HIGH_SCORE() : base("AroundMeLeaderboardRequest"){
			request.AddString("leaderboardShortCode", "HIGH_SCORE");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new AroundMeLeaderboardResponse_HIGH_SCORE (response);
		}		
		
		/// <summary>
		/// The number of items to return in a page (default=50)
		/// </summary>
		public AroundMeLeaderboardRequest_HIGH_SCORE SetEntryCount( long entryCount )
		{
			request.AddNumber("entryCount", entryCount);
			return this;
		}
		/// <summary>
		/// A friend id or an array of friend ids to use instead of the player's social friends
		/// </summary>
		public AroundMeLeaderboardRequest_HIGH_SCORE SetFriendIds( List<string> friendIds )
		{
			request.AddStringList("friendIds", friendIds);
			return this;
		}
		/// <summary>
		/// Number of entries to include from head of the list
		/// </summary>
		public AroundMeLeaderboardRequest_HIGH_SCORE SetIncludeFirst( long includeFirst )
		{
			request.AddNumber("includeFirst", includeFirst);
			return this;
		}
		/// <summary>
		/// Number of entries to include from tail of the list
		/// </summary>
		public AroundMeLeaderboardRequest_HIGH_SCORE SetIncludeLast( long includeLast )
		{
			request.AddNumber("includeLast", includeLast);
			return this;
		}
		
		/// <summary>
		/// If True returns a leaderboard of the player's social friends
		/// </summary>
		public AroundMeLeaderboardRequest_HIGH_SCORE SetSocial( bool social )
		{
			request.AddBoolean("social", social);
			return this;
		}
		/// <summary>
		/// The IDs of the teams you are interested in
		/// </summary>
		public AroundMeLeaderboardRequest_HIGH_SCORE SetTeamIds( List<string> teamIds )
		{
			request.AddStringList("teamIds", teamIds);
			return this;
		}
		/// <summary>
		/// The type of team you are interested in
		/// </summary>
		public AroundMeLeaderboardRequest_HIGH_SCORE SetTeamTypes( List<string> teamTypes )
		{
			request.AddStringList("teamTypes", teamTypes);
			return this;
		}
	}
}

namespace GameSparks.Api.Responses{
	
	public class _LeaderboardEntry_HIGH_SCORE : LeaderboardDataResponse._LeaderboardData{
		public _LeaderboardEntry_HIGH_SCORE(GSData data) : base(data){}
		public long? SCORER{
			get{return response.GetNumber("SCORER");}
		}
	}
	
	public class LeaderboardDataResponse_HIGH_SCORE : LeaderboardDataResponse
	{
		public LeaderboardDataResponse_HIGH_SCORE(GSData data) : base(data){}
		
		public GSEnumerable<_LeaderboardEntry_HIGH_SCORE> Data_HIGH_SCORE{
			get{return new GSEnumerable<_LeaderboardEntry_HIGH_SCORE>(response.GetObjectList("data"), (data) => { return new _LeaderboardEntry_HIGH_SCORE(data);});}
		}
		
		public GSEnumerable<_LeaderboardEntry_HIGH_SCORE> First_HIGH_SCORE{
			get{return new GSEnumerable<_LeaderboardEntry_HIGH_SCORE>(response.GetObjectList("first"), (data) => { return new _LeaderboardEntry_HIGH_SCORE(data);});}
		}
		
		public GSEnumerable<_LeaderboardEntry_HIGH_SCORE> Last_HIGH_SCORE{
			get{return new GSEnumerable<_LeaderboardEntry_HIGH_SCORE>(response.GetObjectList("last"), (data) => { return new _LeaderboardEntry_HIGH_SCORE(data);});}
		}
	}
	
	public class AroundMeLeaderboardResponse_HIGH_SCORE : AroundMeLeaderboardResponse
	{
		public AroundMeLeaderboardResponse_HIGH_SCORE(GSData data) : base(data){}
		
		public GSEnumerable<_LeaderboardEntry_HIGH_SCORE> Data_HIGH_SCORE{
			get{return new GSEnumerable<_LeaderboardEntry_HIGH_SCORE>(response.GetObjectList("data"), (data) => { return new _LeaderboardEntry_HIGH_SCORE(data);});}
		}
		
		public GSEnumerable<_LeaderboardEntry_HIGH_SCORE> First_HIGH_SCORE{
			get{return new GSEnumerable<_LeaderboardEntry_HIGH_SCORE>(response.GetObjectList("first"), (data) => { return new _LeaderboardEntry_HIGH_SCORE(data);});}
		}
		
		public GSEnumerable<_LeaderboardEntry_HIGH_SCORE> Last_HIGH_SCORE{
			get{return new GSEnumerable<_LeaderboardEntry_HIGH_SCORE>(response.GetObjectList("last"), (data) => { return new _LeaderboardEntry_HIGH_SCORE(data);});}
		}
	}
}	

namespace GameSparks.Api.Messages {


}
