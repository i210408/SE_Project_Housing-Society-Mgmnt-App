﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLayer;

namespace BusinessLogicLayer
{
    internal class FeedbackManager
    {
        public static List<string> RetrieveAllFeedbacks()
        {
            return DB.GetAllFeedbacks();
        }

        public static List<string> RetrieveFeedbackByUser(string username)
        {
            return DB.GetFeedbacksByUsername(username);
        }

        public static void InsertFeedback(int userID, string serviceName, string feedbackText,int feedbackRating)
        {
            DB.InsertFeedback(userID,serviceName, feedbackText, feedbackRating);
        }
    }
}
