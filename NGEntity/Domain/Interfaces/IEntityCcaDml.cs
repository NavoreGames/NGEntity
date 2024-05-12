namespace NGEntity.Interfaces;

public interface IEntityCcaDml<TSource>
{
    IEntityCcaCommit Insert();
    IEntityCcaCommit Update();
    IEntityCcaCommit Delete();
}
