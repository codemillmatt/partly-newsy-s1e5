Welcome back to Partly Cloudy! The show where you learn how to build a cloud-connected Xamarin mobile application. We start from nothing and don't quit until it's ready for the App Store!

# Episode Recap

This episode saw us add some user interface polish by harnessing yet more power of [Xamarin.Forms Shell](https://docs.microsoft.com/xamarin/xamarin-forms/app-fundamentals/shell/?WT.mc_id=partlycloudy-github-masoucou).

In episode 3, we used Shell to give the app a basic UI structure and to provide navigation between pages.

But Shell does more. And we explored some of that extra power by showing how we can style it for some cool looks by adding additional top tabs, making the bottom tabs display images, and making both customized with styles.

And we also added in a custom view and modified the back button in the navigation bar too!

If you haven't yet, [go check the episode out on Ch9](https://channel9.msdn.com/Shows/Partly-Cloudy/If-The-Shell-Fits-Fill-out-the-rest-of-the-app?WT.mc_id=partlycloudy-github-masoucou)!

## What We're Going To Do

In this post, I want to take a little closer look at how to use Shell to [build up the tabs](https://docs.microsoft.com/xamarin/xamarin-forms/app-fundamentals/shell/tabs?WT.mc_id=partlycloudy-github-masoucou), custom navigation bars, and styles.

Then I'll dive a bit into how we could build up a flyout menu that replaces the `TabBar` functionality. If you don't like tabs - you could have a flyout instead!

### Tabs! Tabs! Tabs!

In the previous episode on Shell, we built out a simple structure using a `TabBar`.

By building up a XAML structure that looks like the following - you can get multiple bottom tabs for your application:

```language-csharp
<TabBar>
  <Tab>
    <ShellContent>
      <YOUR COOL PAGE GOES HERE>
    </ShellContent>
  </Tab>
  <Tab>
    <ShellContent>
      <ANOTHER COOL PAGE>
    </ShellContent>
  </Tab>
</TabBar>
```

By having multiple `<Tab>` elements within a single `<TabBar>` element - you get tabs along the bottom of your app. And within those `<Tab>` elements - you put the page you want to display inside a `<ShellContent>` element.

So far, so good.

But what would happen if you put multiple `<ShelLContent>` elements inside a single `<Tab>`??

Or something like this:

```language-csharp
<TabBar>
  <Tab>
    <ShellContent>
      <YOUR COOL PAGE GOES HERE>
    </ShellContent>
    <ShellContent>
      <ALL YOU HAVE ARE COOL PAGES>
    </ShellContent>
  </Tab>
  <Tab>
    <ShellContent>
      <ANOTHER COOL PAGE>
    </ShellContent>
  </Tab>
</TabBar>
```
Did you guess that you'd get a compile error? WRONG-O BUCK-O!

Instead you'll get tabs across the top of your application! So now you can have tabs on the bottom AND tabs on the top.

### Styles

So now you're saying ... that's cool, but now I really want to make those tabs my own, and have them look the way I want them to.

> That's cool, but now I really want to make those tabs my own.

Not a problem cuz you can style elements of Shell. You want the title color of the tab bar to be red?

```language-xaml
<Setter Property="Shell.TabBarTitleColor" Value="Red">
```

Pop that little tidbit into your other style definitions and then title (and images) of the tabs will become red.

And speaking of tab images - you can add some easily via the `Tab.Icon` property. In fact, check out the code in the repo on how I added some images using a a font with glyphs.

Tabs aren't the only thing you can style in Shell. You can style entire pages that appear within the Shell, title colors in nav bars, disabled colors, and so on. [Check out this article](https://docs.microsoft.com/xamarin/xamarin-forms/app-fundamentals/shell/configuration?WT.mc_id=partlycloudy-github-masoucou) for more info.

### Customizing Nav Bars

Speaking of customizing ... [making the navigation bars look exactly the way you want](https://docs.microsoft.com/xamarin/xamarin-forms/app-fundamentals/shell/configuration?WT.mc_id=partlycloudy-github-masoucou#display-views-in-the-navigation-bar) them to is a matter of adding a little bit of code to Shell.

We gave our nav bars some extra fat fonts for the title and positioned them exactly where we wanted to using this code:

```language-xaml
<Shell.TitleView>
    <StackLayout>
        <Label Text="Explore"
            TextColor="#171717"
            FontSize="24"
            FontAttributes="Bold"
            Margin="-10,14,0,0"
            HorizontalTextAlignment="Center"
            VerticalTextAlignment="Center"
            VerticalOptions="Center"
            HorizontalOptions="Center" />
    </StackLayout>
</Shell.TitleView>
```

That's right - Shell provides a `TitleView` element and you can put whatever you want in there (well, pretty much whatever). Above there's a `StackLayout`. But it doesn't take too much imagination to see a `Grid` in there with a complicated layout ... if that's what you wanted.

The `TitleView` does not cover customization of the back button though - that's where the `<Shell.BackButtonBehavior>` comes in.

In that element you can add a bunch of different behaviors to the back button, such as adding a `Command` to it. Setting the `Icon` or `Text` of the button. Or even enabling or disabling it.

In our app, we changed the button to display a stylized chevron for the back button.

```language-xaml
<Shell.BackButtonBehavior>
    <BackButtonBehavior>
        <BackButtonBehavior.IconOverride>
            <FontImageSource FontFamily="{StaticResource FabMDL2}" Glyph="&#xE76B;" Size="20" />
        </BackButtonBehavior.IconOverride>
    </BackButtonBehavior>
</Shell.BackButtonBehavior>
```

## Fly Me To The Moon

Shell isn't just limited to tabs though - we can add on a [flyout menu](https://docs.microsoft.com/xamarin/xamarin-forms/app-fundamentals/shell/flyout?WT.mc_id=partlycloudy-github-masoucou) too. You may be accustomed to seeing those via a hamburger icon in some apps.

So I want to show you how to do this. In the finished app, we won't have a flyout - but just for this extra special bonus section - we will.

Here's what it'll look like.

![flyout instead of tabs](https://res.cloudinary.com/code-mill-technologies-inc/image/upload/bo_1px_solid_rgb:000000,c_scale,e_shadow:10,h_600/v1573687184/Simulator_Screen_Shot_-_iPhone_11_-_2019-11-13_at_15.14.47_sk3o0n.png)

So here the first five options are all replacements for the tabs. One for one.

Above them is a spiffy image that is the overall logo for our flyout. To give it a little visual pizzazz.

Then under the _Display Options_ heading are 3 items that would let you change how the news is displayed. (That's not implemented yet, but will be in a future episode.)

So let's break this down step by step.

Instead of using a `TabBar` as the top-level element in the `Shell` page, we add individual `FlyoutItem` elements to it.

Having a `FlyoutItem` will make a row appear in the flyout - and when clicking on that row - will navigate to the page referenced in it.

```language-xaml
<FlyoutItem Title="My Interests">
    <FlyoutItem.Icon>
        <FontImageSource
            Color="Red"
            FontFamily="{StaticResource FabMDL2}"
            Glyph="&#xE734;" />
    </FlyoutItem.Icon>
    <ShellContent>
        <local:MyInterestsPage />
    </ShellContent>
</FlyoutItem>
```

Here you can see that we can set the icon that's displayed in the flyout (to a `FontImageSource` no less) and then the `Page` appears within a `ShellContent` element.

We can still do top tabs though!

Pop in a `Tab` element within the `FlyoutItem` and put a couple of `ShellContent` elements in there - and top tabs you will have:

```language-xaml
<FlyoutItem Title="The News">
    <FlyoutItem.Icon>
        <FontImageSource
            Color="Red"
            FontFamily="{StaticResource FabMDL2}"
            Glyph="&#xE900;" />
    </FlyoutItem.Icon>
    <Tab Title="My News">
        <ShellContent Title="My News">
            <local:NewsCollectionPage Title="My News" />
        </ShellContent>
        <ShellContent Title="Top News">
            <local:NewsCollectionPage Title="Top News" />
        </ShellContent>
    </Tab>
</FlyoutItem>
```

The `FlyoutItems` will display pages. But if you want an _Action_ to happen when the user taps on an item in the flyout menu ... not necessarily a new page to be displayed ... then you use a `MenuItem` element.

A good example would be to change the density of the news article display.

```language-xaml
<MenuItem>
    <Shell.MenuItemTemplate>
        <DataTemplate>
            <StackLayout Padding="16,0,0,0" Orientation="Horizontal">
                <Label FontFamily="{StaticResource SegMDL2}" Text="&#xECA5;" VerticalTextAlignment="Center" FontSize="18" TextColor="Red" />
                <Label Text="Standard" FontSize="14" VerticalTextAlignment="Center"
                        Margin="17,0"/>
                <Label FontFamily="{StaticResource SegMDL2}" Text="&#xE73E;"
                        Margin="0,0,20,0"
                        VerticalTextAlignment="Center" HorizontalOptions="EndAndExpand"
                        FontSize="18" TextColor="Red" />
            </StackLayout>
        </DataTemplate>
    </Shell.MenuItemTemplate>
</MenuItem>
```

What's cool here is that I'm using a `Shell.MenuItemTemplate` to customize what the `MenuItem` looks like. This way I can get that highly customized & polished look that I'm after. _(And once I add in some MVVM, this starts to become a very powerful way of doing things!)_

So to see the new flyout menu based navigation - change the `MainPage` in `App.xaml.cs` to be `FlyoutShellPage`.

## Sum It All Up

So there you have it! We're using Xamarin.Forms Shell now for more than just a wrapper for our app. It's still a wrapper - but it gives us a lot of ways to customize that look and feel. Tabs on top of tabs. Back button behaviors. And 100% custom views in the navigation bar. 

And we explored some ways to replace a tab bar with a flyout menu too!

Things start to get interesting next week when we start to look at the `CollectionView`!