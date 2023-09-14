namespace Final_youtube.Model
{
    public interface InterfMediaAttachment
    {
        List<MediaAttachment> GetMediaAttachments();
        MediaAttachment GetMediaAttachmentById(int attachmentId);
        void AddMediaAttachment(MediaAttachment attachment);
        void DeleteMediaAttachment(int id);
        void UpdateMediaAttachment(MediaAttachment attachment);
    }
}
