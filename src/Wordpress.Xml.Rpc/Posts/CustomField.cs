using CookComputing.XmlRpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wordpress.Xml.Rpc
{
    /// <summary>
    /// An object representing any custom WordPress fields added to a post
    /// </summary>
    public struct CustomField
    {
        [XmlRpcMember("id")]
        public string Id;

        [XmlRpcMember("key")]
        public string Key;

        [XmlRpcMember("value")]
        public string Value;
    }
}
