using CookComputing.XmlRpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wordpress.Xml.Rpc
{
    [XmlRpcMissingMapping(MappingAction.Ignore)]
    public class Author
    {
        [XmlRpcMember("user_id")]
        public string Id;

        [XmlRpcMember("user_login")]
        public string LoginName;

        [XmlRpcMember("display_name")]
        public string DisplayName;
    }
}
