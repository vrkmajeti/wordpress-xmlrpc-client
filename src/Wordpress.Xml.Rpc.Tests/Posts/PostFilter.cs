using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Should.Fluent;
using Xunit;

namespace Wordpress.Xml.Rpc.Tests.Posts
{
    public class PostFilter
    {
        public class Constructor
        {
            private Rpc.PostFilter _subject = new Rpc.PostFilter();

            [Fact]
            public void DefaultsPostStatusValue()
            {
                this._subject.PostStatus.Should().Equal(PostStatus.Any);
            }

            [Fact]
            public void DefaultsNumberValue()
            {
                this._subject.Number.Should().Equal(10);
            }

            [Fact]
            public void DefaultsPostType()
            {
                this._subject.PostType.Should().Equal("post");
            }

            [Fact]
            public void DefaultsOrderBy()
            {
                this._subject.OrderBy.Should().Equal(PostOrderBy.None);
            }

            [Fact]
            public void DefaultsOrder()
            {
                this._subject.Order.Should().Equal(Order.Ascending);
            }
        }
    }
}
