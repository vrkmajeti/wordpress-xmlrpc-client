using CookComputing.XmlRpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordpress.Xml.Rpc
{
    public interface IWordpressProxy : IXmlRpcProxy
    {
        [XmlRpcMethod("wp.getPosts")]
        Post[] GetPosts(int blogId, string username, string password, PostFilterProxy? filter);

        [XmlRpcMethod("wp.getPost")]
        Post GetPost(int blogId, string username, string password, int postId);

        [XmlRpcMethod("wp.getAuthors")]
        Author[] GetAuthors(int blogId, string username, string password);
    }
}
