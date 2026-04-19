using OpenQA.Selenium;

namespace TAF.Business.PageObject.Pages;

public class ArticlePage: BasePage
{
    private readonly By _articleName = By.CssSelector(".header_and_download .museo-sans-light");

    public ArticlePage(IWebDriver driver): base(driver) { }
    
    public string GetArticleName()
    {
        return Driver.FindElement(_articleName).Text.Trim();
    }    
}
