﻿namespace Traversal_Core_Project.CQRS.Results.GuideResults
{
    public class GetGuideByIdQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string TwitterUrl { get; set; }
        public string InstagramUrl { get; set; }
        public bool Status { get; set; }
    }
}
