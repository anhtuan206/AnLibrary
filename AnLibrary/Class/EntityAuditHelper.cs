using System;

namespace AnLibrary.Class
{
    public static class EntityAuditHelper
    {
        /// <summary>
        /// Thiết lập thông tin ngày tạo và người tạo cho thực thể mới.
        /// Đồng thời thiết lập cả thông tin người thay đổi cuối cùng.
        /// </summary>
        /// <param name="entity">Đối tượng cần cập nhật</param>
        /// <param name="currentUser">Tên người dùng hiện tại</param>
        public static void SetCreatedInfo(object entity, string currentUser)
        {
            var type = entity.GetType();

            type.GetProperty("CreatedBy")?.SetValue(entity, currentUser);
            type.GetProperty("CreatedDate")?.SetValue(entity, DateTime.Now);

            SetChangedInfo(entity, currentUser);
        }

        /// <summary>
        /// Thiết lập thông tin ngày thay đổi và người thay đổi cho thực thể.
        /// </summary>
        /// <param name="entity">Đối tượng cần cập nhật</param>
        /// <param name="currentUser">Tên người dùng hiện tại</param>
        public static void SetChangedInfo(object entity, string currentUser)
        {
            var type = entity.GetType();

            type.GetProperty("ChangedBy")?.SetValue(entity, currentUser);
            type.GetProperty("ChangedDate")?.SetValue(entity, DateTime.Now);
        }
    }
}
