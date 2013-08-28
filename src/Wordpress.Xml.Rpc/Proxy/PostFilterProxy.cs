using CookComputing.XmlRpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordpress.Xml.Rpc
{
    public struct PostFilterProxy
    {
        [XmlRpcMember("post_type")]
        public string PostType;

        [XmlRpcMember("post_status")]
        public string[] PostStatus;

        [XmlRpcMember("number")]
        public int Number;

        [XmlRpcMember("offset")]
        public int Offset;

        [XmlRpcMember("orderby")]
        public string OrderBy;

        [XmlRpcMember("order")]
        public string Order;
    }
}
