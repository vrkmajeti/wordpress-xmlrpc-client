using CookComputing.XmlRpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wordpress.Xml.Rpc
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class MediaItem
    {
        [XmlRpcMember("attachment_id")]
        public string AttachmentId;

        [XmlRpcMember("date_created_gmt")]
        public DateTime DateCreatedGMT;

        [XmlRpcMember("parent")]
        public int Parent;

        [XmlRpcMember("link")]
        public string Link;

        [XmlRpcMember("title")]
        public string Title;

        [XmlRpcMember("caption")]
        public string Caption;

        [XmlRpcMember("description")]
        public string Description;

        //public object metadata;
        //public object image_meta;

        [XmlRpcMember("thumbnail")]
        public string ThumbnailLink;
    }
}
