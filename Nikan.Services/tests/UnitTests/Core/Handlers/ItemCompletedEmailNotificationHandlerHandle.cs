//using Moq;
//using Nikan.Services.BasicData.Core.Interfaces;
//using Xunit;

//namespace Nikan.Services.BasicData.UnitTests.Core.Handlers;

//public class ItemCompletedEmailNotificationHandlerHandle
//{
//  private readonly Mock<IEmailSender> _emailSenderMock;
//  private ItemCompletedEmailNotificationHandler _handler;

//  public ItemCompletedEmailNotificationHandlerHandle()
//  {
//    _emailSenderMock = new Mock<IEmailSender>();
//    _handler = new ItemCompletedEmailNotificationHandler(_emailSenderMock.Object);
//  }

//  [Fact]
//  public async Task ThrowsExceptionGivenNullEventArgument()
//  {
//#nullable disable
//    Exception ex = await Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(null, CancellationToken.None));
//#nullable enable
//  }

//  [Fact]
//  public async Task SendsEmailGivenEventInstance()
//  {
//    await _handler.Handle(new ToDoItemCompletedEvent(new ToDoItem()), CancellationToken.None);

//    _emailSenderMock.Verify(
//      sender => sender.SendEmailAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()),
//      Times.Once);
//  }
//}
