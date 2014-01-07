using AutoMapper;
using CookComputing.XmlRpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using Should.Fluent;
using Xunit;

namespace Wordpress.Xml.Rpc.Tests.Posts
{
    public class Post
    {
        public class XmlRpcSerializer
        {
            private Rpc.Post _subject;
            private Rpc.Post _expected;

            public XmlRpcSerializer()
            {
                Mapper.Initialize((config) =>
                {
                    config.CreateMap<PostStatus, string>().ConvertUsing(src => src.ToRPC());
                    config.CreateMap<PostOrderBy, string>().ConvertUsing(src => src.ToRPC());
                    config.CreateMap<Order, string>().ConvertUsing(src => src.ToRPC());
                    config.CreateMap<Rpc.PostFilter, PostFilterProxy>()
                        .ForMember(
                            dest => dest.PostStatus,
                            opt => opt.MapFrom(
                                source => new string[] { Mapper.Map<string>(source.PostStatus) }
                            )
                        );
                });               

                var doc = new XmlDocument();
                doc.Load("SampleData/getpost.xml");

                var response = new CookComputing.XmlRpc.XmlRpcSerializer().DeserializeResponse(
                        doc, 
                        typeof(Rpc.Post)
                    );

                this._subject = response.retVal as Rpc.Post;
                this._expected = this.ExpectedPost();
            }

            [Fact]
            public void MapsId()
            {
                this._subject.Id.Should().Equal(this._expected.Id);
            }

            [Fact]
            public void MapsTitle()
            {
                this._subject.Title.Should().Equal(this._expected.Title);                
            }

            [Fact]
            public void MapsPostDate()
            {
                this._subject.PostDate.Should().Equal(this._expected.PostDate);
            }

            [Fact]
            public void MapsPostDateGMT()
            {
                this._subject.PostDateGMT.Should().Equal(this._expected.PostDateGMT);
            }

            [Fact]
            public void MapsPostModified()
            {
                this._subject.PostModified.Should().Equal(this._expected.PostModified);
            }

            [Fact]
            public void MapsPostModifiedGMT()
            {
                this._subject.PostModifiedGMT.Should().Equal(this._expected.PostModifiedGMT);
            }
            
            [Fact]
            public void MapsStatus()
            {
                this._subject.Status.Should().Equal(this._expected.Status);
            }

            [Fact]
            public void MapsType()
            {
                this._subject.Type.Should().Equal(this._expected.Type);
            }

            [Fact]
            public void MapsName()
            {
                this._subject.Name.Should().Equal(this._expected.Name);
            }

            [Fact]
            public void MapsAuthorId()
            {
                this._subject.AuthorId.Should().Equal(this._expected.AuthorId);
            }

            [Fact]
            public void MapsPassword()
            {
                this._subject.Password.Should().Equal(this._expected.Password);
            }

            [Fact]
            public void MapsExcerpt()
            {
                this._subject.Excerpt.Should().Equal(this._expected.Excerpt);
            }

            [Fact]
            public void MapsContent()
            {
                this._subject.Should().Not.Be.Null();
                this._subject.Should().Not.Equal(string.Empty);
            }

            [Fact]
            public void MapsParent()
            {
                this._subject.Parent.Should().Equal(this._expected.Parent);
            }

            [Fact]
            public void MapsMIMEType()
            {
                this._subject.MIMEType.Should().Equal(this._expected.MIMEType);
            }

            [Fact]
            public void MapsLink()
            {
                this._subject.Link.Should().Equal(this._expected.Link);
            }

            [Fact]
            public void MapsGUID()
            {
                this._subject.GUID.Should().Equal(this._expected.GUID);
            }

            [Fact]
            public void MapsMenuOrder()
            {
                this._subject.MenuOrder.Should().Equal(this._expected.MenuOrder);
            }

            [Fact]
            public void MapsCommentStatus()
            {
                this._subject.CommentStatus.Should().Equal(this._expected.CommentStatus);
            }

            [Fact]
            public void MapsPingStatus()
            {
                this._subject.PingStatus.Should().Equal(this._expected.PingStatus);
            }

            [Fact]
            public void MapsSticky()
            {
                this._subject.Sticky.Should().Equal(this._expected.Sticky);
            }

            [Fact]
            public void MapsTerms()
            {
                this._subject.Terms.Should().Equal(this._expected.Terms);
            }

            [Fact]
            public void MapsCustomFields()
            {
                this._subject.CustomFields.Should().Equal(this._expected.CustomFields);
            }

            private Rpc.Post ExpectedPost()
            {
                // values taken from SampleData/getpost.xml
                var post = new Rpc.Post();
                post.Id = "21991";
                post.Title = "Wedding Blog: Guests That Don't RSVP!";
                post.PostDate = "20101231T00:00:00".ToISO8601DateTime();
                post.PostDateGMT = "20101231T00:00:00".ToISO8601DateTime();
                post.PostModified = "20120423T21:17:01".ToISO8601DateTime();
                post.PostModifiedGMT = "20120423T21:17:01".ToISO8601DateTime();
                post.Status = "publish";
                post.Type = "post";
                post.Name = "wedding-blog-guests-that-dont-rsvp";
                post.AuthorId = "1";
                post.Password = string.Empty;
                post.Excerpt = string.Empty;
                post.Parent = "0";
                post.MIMEType = string.Empty;
                post.Link = "http://blogs.slice.dev.smdg.ca/wedding-blog-guests-that-dont-rsvp/";
                
                post.GUID = "http://blog.slice.ca/wedding-blog-guests-that-dont-rsvp/";                
                post.MenuOrder = 0;
                post.CommentStatus = "open";
                post.PingStatus = "open";
                post.Sticky = false;
                post.Terms = new Term[]{
                    new Term{ Id = "10", Name = "Weddings", Slug="weddings", Group="0", TaxonomyId="10", Taxonomy="category", Description="Weddings", Parent="0", Count=69 }
                };

                post.CustomFields = new CustomField[]{
                    new CustomField{ Id = "54400", Key = "aa", Value="2010" },
                    new CustomField{ Id = "54380", Key = "action", Value="editpost" },
                    new CustomField{ Id = "54434", Key = "advanced_view", Value="1" },
                    new CustomField{ Id = "54388", Key = "autosavenonce", Value="37b9c93717" }
                };
                return post;
            }
        }
    }
}
