﻿using AutoMapper;
using CookComputing.XmlRpc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Wordpress.Xml.Rpc
{
    public class Wordpress
    {
        private int _blogId;
        private NetworkCredential _creds;
        private IWordpressProxy _proxy;

        static Wordpress()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<PostStatus, string>().ConvertUsing(src => src.ToRPC());
                config.CreateMap<PostOrderBy, string>().ConvertUsing(src => src.ToRPC());
                config.CreateMap<Order, string>().ConvertUsing(src => src.ToRPC());
                config.CreateMap<PostFilter, PostFilterProxy>()
                    .ForMember(
                        dest => dest.PostStatus,
                        opt => opt.MapFrom(source => new string[] { Mapper.Map<string>(source.PostStatus) })
                    );
            });         
        }

        public Wordpress()
        {
            this._blogId = int.Parse(ConfigurationManager.AppSettings["WP_XML_RPC_BLOG_ID"]);            
            this._creds = new NetworkCredential(
                    ConfigurationManager.AppSettings["WP_XML_RPC_USERNAME"],
                    ConfigurationManager.AppSettings["WP_XML_RPC_PASSWORD"]
                );

            var url = ConfigurationManager.AppSettings["WP_XML_RPC_URL"];
            this.CreateRPCProxy(new Uri(url));
        }

        public Wordpress(Uri rpcEndpoint, int blogId, string username, string password)
        {
            Guard.AgainstNull("rpcEndpoint", rpcEndpoint);
            Guard.AgainstNullOrEmpty("username", username);
            Guard.AgainstNullOrEmpty("password", password);

            if (blogId <= 0) throw new ArgumentOutOfRangeException("blogId");

            this._blogId = blogId;            
            this._creds = new NetworkCredential(username, password);

            this.CreateRPCProxy(rpcEndpoint);
        }

        private void CreateRPCProxy(Uri rpcEndpoint)
        {
            this._proxy = XmlRpcProxyGen.Create<IWordpressProxy>();
            this._proxy.Url = rpcEndpoint.ToString();
        }

        public virtual Post GetPost(int postId)
        {
            return this._proxy.GetPost(
                    this._blogId,
                    this._creds.UserName,
                    this._creds.Password,
                    postId
                );
        }
        
        public virtual IEnumerable<Post> GetPosts(PostFilter filter)
        {
            var paramFilter = Mapper.Map<PostFilterProxy>(filter);
            
            return this._proxy.GetPosts(
                    this._blogId,
                    this._creds.UserName,
                    this._creds.Password,
                    paramFilter
                );
        }

        public virtual IEnumerable<Author> GetAuthors()
        {
            return this._proxy.GetAuthors(
                    this._blogId,
                    this._creds.UserName,
                    this._creds.Password
                );
        }
    }
}
