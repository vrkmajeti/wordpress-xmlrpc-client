using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wordpress.Xml.Rpc
{
    public enum PostStatus
    {
        Any,
        Published,
        Pending,
        Draft,
        AutoDraft,
        Future,
        Private,
        Inherit,
        Trash,
    }

    public enum PostOrderBy
    {
        None,
        ID,
        Author,
        Title,
        Name,
        Date,
        Modified,
        Parent,
        Random,
        CommentCount,
        MenuOrder,
    }

    public enum Order
    {
        Ascending,
        Descending,
    }

    public class PostFilter
    {
        public string PostType { get; set; }

        public PostStatus PostStatus { get; set; }

        public PostOrderBy OrderBy { get; set; }

        public Order Order { get; private set; }

        public int Number { get; set; }

        public int Offset { get; set; }

        public PostFilter()
        {
            this.PostType = "post";
            this.Number = 10;
            this.PostStatus = Rpc.PostStatus.Any;
            this.Order = Order.Ascending;
            this.OrderBy = PostOrderBy.None;
        }
    }
}
