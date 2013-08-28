using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

using Should.Fluent;

namespace Wordpress.Xml.Rpc.Tests
{
    public class Wordpress
    {
        public class Constructor
        {
            public class WhenGivenParameters
            {
                [Fact]
                public void RequiresRPCEndpoint()
                {
                    Assert.Throws<ArgumentNullException>(() =>
                    {
                        new Rpc.Wordpress(null, 1, "user", "pass");
                    });
                }

                [Fact]
                public void RequiresBlogId()
                {
                    Assert.Throws<ArgumentOutOfRangeException>(() =>
                    {
                        new Rpc.Wordpress(new Uri("http://example.com"), 0, "user", "password");
                    });
                }

                [Fact]
                public void RequiresUsername()
                {
                    Assert.Throws<ArgumentNullException>(() =>
                    {
                        new Rpc.Wordpress(new Uri("http://example.com"), 1, string.Empty, "password");
                    });
                }

                [Fact]
                public void RequiresPassword()
                {
                    Assert.Throws<ArgumentNullException>(() =>
                    {
                        new Rpc.Wordpress(new Uri("http://example.com"), 1, "user", string.Empty);
                    });
                }
            }
        }
    }
}
