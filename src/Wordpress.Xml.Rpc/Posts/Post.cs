using CookComputing.XmlRpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordpress.Xml.Rpc
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Post
    {
        [XmlRpcMember("post_id")]
        public string Id;

        [XmlRpcMember("post_title")]
        public string Title;

        [XmlRpcMember("post_date")]
        public DateTime PostDate;

        [XmlRpcMember("post_date_gmt")]
        public DateTime PostDateGMT;

        [XmlRpcMember("post_modified")]
        public DateTime PostModified;

        [XmlRpcMember("post_modified_gmt")]
        public DateTime PostModifiedGMT;

        [XmlRpcMember("post_status")]
        public string Status;

        [XmlRpcMember("post_type")]
        public string Type;

        [XmlRpcMember("post_format")]
        public string Format;

        [XmlRpcMember("post_name")]
        public string Name;

        [XmlRpcMember("post_author")]
        public string AuthorId;

        [XmlRpcMember("post_password")]
        public string Password;

        [XmlRpcMember("post_excerpt")]
        public string Excerpt;

        [XmlRpcMember("post_content")]
        public string Content;

        [XmlRpcMember("post_parent")]
        public string Parent;

        [XmlRpcMember("post_mime_type")]
        public string MIMEType;

        [XmlRpcMember("link")]
        public string Link;

        [XmlRpcMember("guid")]
        public string GUID;

        [XmlRpcMember("menu_order")]
        public int MenuOrder;

        [XmlRpcMember("comment_status")]
        public string CommentStatus;

        [XmlRpcMember("ping_status")]
        public string PingStatus;

        [XmlRpcMember("sticky")]
        public bool Sticky;

        [XmlRpcMember("post_thumbnail")]
        public object Thumbnail;
    }
}
