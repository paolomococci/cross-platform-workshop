namespace PetLibrary.Shared;
public class PetComparer : IComparer<Pet?>
{
  public int Compare(Pet? first, Pet? second) {
    if ((first is not null) && (second is not null)) {
      if (first.Name is null) {
        if (second.Name is null) return 0;
        return 1;
      } else {
        if (second.Name is null) {
          return -1;
        }
      }
      int result = first.Name.Length.CompareTo(second.Name.Length);
      if (result == 0) {
        return first.Name.CompareTo(second.Name);
      } else {
        return result;
      }
    } else if ((first is not null) && (second is null)) {
      return -1;
    } else if ((first is null) && (second is not null)) {
      return 1;
    } else {
      return 0;
    }
  }
}
