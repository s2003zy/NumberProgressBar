NumberProgressBar
============
NumberProgressBar for Windows Phone 8.1

-----

The NumberProgressBar is a bar, slim and sexy (every man wants! ). 

Thanks to [daimajia](https://github.com/daimajia) design this beautiful Bar.

[daimajia](https://github.com/daimajia) already build it for Android and [Ming-zhe](https://github.com/Ming-Zhe) build it for IOS. So as beginner of Windows Phone 8.1 I decide build it for wp8.1. Hope I could learn more about wp8.1 and share it for every one who want to use it. 

---

###Demo

 ![](https://github.com/s2003zy/Images/blob/master/NumberProgressBar/1.gif)

### Usage

* You should use Visual Studio 2013 with Update 2 or later.

* Use NuGet to add the NumberProgressBar to your Project

  * Open Nuget from Visual Studio
  ![](https://github.com/s2003zy/Images/blob/master/NumberProgressBar/2.jpg)

  * Search "NumberProgressBar" and Install it
  ![](https://github.com/s2003zy/Images/blob/master/NumberProgressBar/3.jpg)

  * add to your project
  
  ![](https://github.com/s2003zy/Images/blob/master/NumberProgressBar/4.jpg)
 
  * Now You could find it in the "References"
  
  ![](https://github.com/s2003zy/Images/blob/master/NumberProgressBar/5.jpg)


* add namespace "Song" to your code

In XAML
```XAML
<Page
    ......
    xmlns:song="using:Song"
    ......
    >
</Page>
```
In c#
```cs
using Song;
```

* Use it and enjoy

```XAML
<song:NumberProgressBar></song:NumberProgressBar>
```
* Use 'Progress' not 'Value'
  if you want to set the Progress you should use 'Progress' property.
* Use some Style

I also move some predesign style from [daimajia](https://github.com/daimajia). You can use them via `ProgressBarStyle` property.

like blow:
```xml
<song:NumberProgressBar
ProgressBarStyle="NumberProgressBar_Passing_Green" >
</song:NumberProgressBar>

```
In the above picture, the style is : 

`NumberProgressBar_Default`
`NumberProgressBar_Passing_Green`
`NumberProgressBar_Relax_Blue`
`NumberProgressBar_Grace_Yellow`
`NumberProgressBar_Warning_Red`
`NumberProgressBar_Funny_Orange`
`NumberProgressBar_Beauty_Red`
`NumberProgressBar_Twinkle_Night`

And you could create your own Style for it.

like blow:
```xml
<StackPanel>
   <StackPanel.Resources>
            <Style x:Key="NumberProgressBar_Default" TargetType="song:NumberProgressBar">
                <Setter Property="Max" Value="100" />
                <Setter Property="Progress" Value="0" />

                <Setter Property="ProgressUnreachedColor" Value="#CCCCCC"/>
                <Setter Property="ProgressReachedColor" Value="#3498DB"/>

                <Setter Property="ProgressTextSize" Value="10"/>
                <Setter Property="ProgressTextColor" Value="#3498DB" />

                <Setter Property="ProgressReachedBarHeight" Value="1.5"/>
                <Setter Property="ProgressUnreachedBarHeight" Value="0.75"/>

            </Style>
        </StackPanel.Resources>

        <song:NumberProgressBar x:Name="song" Margin="0,60,0,0" Loaded="song_Loaded" Style="{StaticResource NumberProgressBar_Default}"></song:NumberProgressBar>
</StackPanel>

```



You can get more beautiful color from [kular](https://kuler.adobe.com), and you can also contribute your color style to NumberProgressBar!  



###Attributes

There are several attributes you can set:

![](http://ww2.sinaimg.cn/mw690/610dc034jw1efyttukr1zj20eg04bmx9.jpg)

The **reached area** and **unreached area**:

* color
* height 

The **text area**:

* color
* text size

The **bar**:

* max progress
* current progress

### About me:

A student in mainland China

Welcom to contact me.

Also welcom to offer me intership.Thanks in advances. ^_^ 

My blog: [http://blog.s2003zy.com](http://blog.s2003zy.com)

My email:[s2003zy@gmail.com](mailto:s2003zy@gmail.com)


