using CookComputing.XmlRpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using Should.Fluent;
using Xunit;
using System.Collections;

namespace Wordpress.Xml.Rpc.Tests.Posts
{
    public class Authors
    {
        public class XmlRpcSerializer
        {
            private IEnumerable<Rpc.Author> _subject;
            private IEnumerable<Rpc.Author> _expected;

            public XmlRpcSerializer()
            {
                var doc = new XmlDocument();
                doc.Load("SampleData/getAuthors.xml");

                var response = new CookComputing.XmlRpc.XmlRpcSerializer().DeserializeResponse(
                        doc,
                        typeof(Rpc.Author[])
                    );

                this._subject = response.retVal as IEnumerable<Rpc.Author>;

                //= new List<Author>();
                
                this._expected = this.ExpectedAuthors();
            }

            [Fact]
            public void MapsAuthors()
            {
                Assert.Equal<Author>(_expected, _subject, new LambdaComparer<Author>((x, y) => x.Id == y.Id && x.LoginName == y.LoginName && x.DisplayName == y.DisplayName));
            }

            private IEnumerable<Author> ExpectedAuthors()
            {
                // values taken from SampleData/getpost.xml
                var authors = new Rpc.Author[]{
                    new Author{ Id = "85", LoginName="acthomson", DisplayName="Alicia Cox Thomson" },
                    new Author{ Id = "125", LoginName="adenaleigh", DisplayName="adenaleigh" },
                };

                return authors;
            }
        }
    }

}
