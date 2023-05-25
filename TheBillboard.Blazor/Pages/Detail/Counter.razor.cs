namespace TheBillboard.Blazor.Pages.Detail;

using Microsoft.AspNetCore.Components;
using TheBillboard.Data.Abstract;
using TheBillboard.Data.Models;

public partial class Counter
{
    private string _title = "Message Detail";
    
    [Inject] private IGateway<Message> Gateway { get; set;}

    private Message Message { get; set;}

    [Parameter] public int Id { get; set; }

    protected override void OnParametersSet()
    {
        Message = Gateway.GetById(Id);
    }
}