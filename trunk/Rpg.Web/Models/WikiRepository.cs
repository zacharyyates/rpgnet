/* Zachary Yates
 * Copyright © 2007 YatesMorrison Software Company
 * 7/20/2008 7:04
 */

namespace Rpg.Web.Models
{
    public class TopicRepository : Repository<Topic>
    {
		public TopicRepository(WikiModelDataContext context) : base(context) { }
    }
}