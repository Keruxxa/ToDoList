   M S B A M L   `   `   `  ????F  BWpfToDoList, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WpfToDoListWpfToDoList  5   	   "    WpfToDoList.MessageBoxCustom   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:WpfToDoList     5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     ? Title$  MessageBoxWindow??5   	   $	??236??6"   $	??500??6/   
??????  ? WindowStartupLocation$ CenterScreen=?5	   	    ? WindowStyle$
 None=?6.    ? 
ResizeMode$ NoResize=?5
   	    ? Topmost .  ? ShowInTaskbar .     MaterialDesignBody#???   5   	   $??Regular"?5   	   $??10(?5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=?5   	      TextRenderingMode$
 Auto=?5   	     MaterialDesignFont#???  5   	   .??5      ??  ?? CornerRadius$ 15??6   ???#0e123e$??5q?5      ._?5   
   ? 	 ? ColumnDefinitions	 5      ?? 5      $	??16* ?6#   ?? 5      $	??82* ?6#   ?? 5      $	??51* ?6#   ?? 5      $	??96* ?6#   
 ? RowDefinitions
 5      ?? 5      $
??auto ?6    ?? 5      $??* ?6    .+?5       #  MaterialDesignThemes.Wpf.Card  -   5          Name$ 
cardHeader??5    "   $??0??66   $??10q?6C   ???#0e123e ! PrimaryHueDarkForegroundBrush#???  6e   $y?Visible=?5!      $??4??6   .??5"      ?? .+?5#      ?? -   5         ??Name$ txtTitle??5#       $??Center=?62   $??Stretch=?6O      MaterialDesignTitleTextBlock#???  6k   $??20(?6?   Message Title6?   5$      5%      ?? 5&      $
??Left=?6   $??	152,0,0,0q?65   $??Center=?6I   $??3??6d   .+?5'      ?? -   5         ??Name$ btnClose??5'      $??35??6B   $??35??6M   
???????  PrimaryHueDarkBrush#???  6m    * &MaterialDesignFloatingActionDarkButton#??[ 6?   .??5(      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Close=?6.   5)      5*      ? 5+      $??4??6   
???????$??0,44,0,0q?6:   $??2??6L   .+?5,      ? $??20q?6   
 5-      ?? 5.      $
??auto ?6(   ?? 5/      $
??auto ?6(   ?? 50      $??* ?6(   .+?53      ? $??0??6   
 54      ?? 55      $
??auto ?6,   ?? 56      $??* ?6,   .+?59      ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  .??5:      ?? -   5         ??Name$ 
txtMessage??5:   &   $??Center=?6:    ?? 
IsReadOnly . $??0??6i   $??5q?6v   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$  ??6?   $??18(?6?    % !MaterialDesignFloatingHintTextBox#??[ 6?   5;      5=      ? 5>      $??1??6   $??0,20,0,5q?6(   	 5?      ?? 5@      $??* ?6/   ?? 5A      $
??auto ?6/   ?? 5B      $
??auto ?6/   ?? 5C      $??* ?6/   .+?5F      ?? -   5        $ btnOk??5F   !   $??1??6D     TasksButtonStyle#???  6T   $??5q?6   $	??100??6?   $??OK??6?   ?? 5G      -   5        $ 	btnCancel??5G   !   $??2??6L   #???  6\   $??5q?6?   $	??100??6?   $??Отмена??6?   ?? 5H      -   5        $ btnYes??5H   !   $??1??6F   #???  6V   $??5q?6?   $	??100??6?   $
??Да??6?   ?? 5I      -   5        $ btnNo??5I   !   $??2??6D   #???  6T   $??5q?6   $	??100??6?   $??Нет??6?   5J      5L      5M      5N      5O      5P      