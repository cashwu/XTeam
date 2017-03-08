using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace XTeam.Models.EntityMetadata
{
    [MetadataType(typeof(ScriptsMetaData))]
    public partial class Scripts
	{
	}

    public partial class ScriptsMetaData
    {
        public int Id { get; set; }

		[DisplayName("Script Name")]
        public string Name { get; set; }

        [AllowHtml]
        public string SqlCommand { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}