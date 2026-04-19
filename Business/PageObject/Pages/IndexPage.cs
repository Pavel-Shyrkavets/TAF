using OpenQA.Selenium;

namespace TAF.Business.PageObject.Pages;

public class IndexPage: BasePage
{
    private readonly By _acceptAllButton = By.Id("onetrust-accept-btn-handler");

    private readonly By _hamburgerMenuButton = By.ClassName("hamburger-menu__button");

    private readonly By _insightsButton = By.XPath("//li[@gradient-text='Insights']");

    private readonly By _aiInsightsButton = 
        By.XPath("//li[@class='hamburger-menu__item ']/a[@href='/insights/ai']");
    
    public IndexPage(IWebDriver driver) : base(driver) { }

    public IndexPage Open(string url)
    {
        Driver.Url = url;
        return this;
    }

    public void AcceptAllCookies()
    {
        Driver.FindElement(_acceptAllButton).Click();
    }
    
    public void ClickHamburgerMenuButton()
    {
        Driver.FindElement(_hamburgerMenuButton).Click();
    }
    
    public void ClickInsightsButton()
    {
        Driver.FindElement(_insightsButton).Click();
    }

    public InsightsPage ClickAIInsightsButton()
    {
        Driver.FindElement(_aiInsightsButton).Click();
        return new InsightsPage(Driver);
    }
}
