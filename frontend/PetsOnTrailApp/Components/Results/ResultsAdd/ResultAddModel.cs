using System.ComponentModel.DataAnnotations;

namespace PetsOnTrailApp.Components.ResultsAdd;

public sealed record ResultAddModel
{
    public Guid Id { get; set; } = Guid.Empty;

    [Required(ErrorMessage = "FirstName is required.")]
    [StringLength(50, ErrorMessage = "FirstName must be no more than 50 characters.")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "LastName is required.")]
    [StringLength(50, ErrorMessage = "NaLastNameme must be no more than 50 characters.")]
    public string LastName { get; set; } = string.Empty;

    public List<string> Pets { get; set; } = new List<string>();

    [Required(ErrorMessage = "Start is required.")]
    public DateTimeOffset? Start { get; set; } = null;

    [Required(ErrorMessage = "Finish is required.")]
    public DateTimeOffset? Finish { get; set; } = null;

    public ResultState State { get; set; } = ResultState.NotValid;

    public enum ResultState
    {
        NotValid = 0,
        NotStarted,
        Started,
        Finished,
        DidNotFinished,
        Disqualified
    }
}
