Welcome back to Partly Cloudy! The show where you learn how to build a cloud-connected Xamarin mobile application. We start from nothing and don't quit until it's ready for the App Store!

# Episode Recap

This episode saw us add some user interface polish by harnessing yet more power of Xamarin.Forms Shell.

In episode 3, we used Shell to give the app a basic UI structure and to provide navigation between pages.

But Shell does more. And we explored some of that extra power by showing how we can style it for some cool looks by adding additional top tabs, making the bottom tabs display images, and making both customized with styles.

And we also added in a custom view and modified the back button in the navigation bar too!

## What We're Going To Do

In this post, I want to take a little closer look at how to use Shell to build up the tabs, custom navigation bars, and styles.

Then I'll dive a bit into how we could build up a flyout menu that duplicates the functionality seen in the current Settings page.

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

Speaking of customizing ... making the navigation bars look exactly the way you want them to is a matter of adding a little bit of code to Shell.

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

So I want to show you how to do this. In the finished app, we won't have a flyout - but just for this extra special bonus session - we will.


## Sum It All Up