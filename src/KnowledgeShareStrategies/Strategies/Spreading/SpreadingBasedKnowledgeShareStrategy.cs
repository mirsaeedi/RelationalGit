﻿using Microsoft.Extensions.Logging;

namespace RelationalGit.KnowledgeShareStrategies.Strategies.Spreading
{
    public class SpreadingBasedKnowledgeShareStrategy : ScoreBasedSpreadingKnowledgeShareStrategy
    {
        public SpreadingBasedKnowledgeShareStrategy(string knowledgeSaveReviewerReplacementType, ILogger logger, string pullRequestReviewerSelectionStrategy, bool? addOnlyToUnsafePullrequests,string recommenderOption)
            : base(knowledgeSaveReviewerReplacementType, logger, pullRequestReviewerSelectionStrategy, addOnlyToUnsafePullrequests,recommenderOption)
        {
        }

        internal override double ComputeReviewerScore(PullRequestContext pullRequestContext, DeveloperKnowledge reviewer)
        {
            var specializedKnowledge = reviewer.NumberOfTouchedFiles / (double)pullRequestContext.PullRequestFiles.Length;
            return 1 - specializedKnowledge;
        }
    }
}