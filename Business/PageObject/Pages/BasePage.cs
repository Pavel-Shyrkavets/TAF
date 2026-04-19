using OpenQA.Selenium;

namespace TAF.Business.PageObject.Pages;

public abstract class BasePage
{
    protected static IWebDriver Driver;

    protected BasePage(IWebDriver driver)
    {
        Driver = driver;
    }
}
