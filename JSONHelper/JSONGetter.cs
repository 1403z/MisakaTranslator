using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace JSONHelper
{
    public class JSONGetter
    {
        private JObject JSONObj;
        public JSONGetter(JObject @object)
        {
            JSONObj = @object;
        }

        public JSONGetter this[string propertyName]
        {
            get
            {
                if(!JSONObj.ContainsKey(propertyName))//若无此Token
                {
                    JSONObj.Add(propertyName, new JObject());//添加
                }
                JSONObj = JSONObj[propertyName].ToObject<JObject>();//向下一层
                return this;
            }
            set
            {
                if(!JSONObj.ContainsKey(propertyName))
                {
                    JSONObj.Add(propertyName, value.JSONObj);
                }
                JSONObj = JSONObj[propertyName].ToObject<JObject>();
            }
        }
    }
}
