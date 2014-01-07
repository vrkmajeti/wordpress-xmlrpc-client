using CookComputing.XmlRpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wordpress.Xml.Rpc
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public struct Term
    {
        [XmlRpcMember("term_id")]
        public string Id;

        [XmlRpcMember("name")]
        public string Name;

        [XmlRpcMember("slug")]
        public string Slug;

        [XmlRpcMember("term_group")]
        public string Group { get; set; }

        [XmlRpcMember("term_taxonomy_id")]
        public string TaxonomyId { get; set; }

        [XmlRpcMember("taxonomy")]
        public string Taxonomy { get; set; }

        [XmlRpcMember("description")]
        public string Description { get; set; }

        [XmlRpcMember("parent")]
        public string Parent { get; set; }

        [XmlRpcMember("count")]
        public int Count { get; set; }
    }
}
