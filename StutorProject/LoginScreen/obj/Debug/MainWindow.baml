   M S B A M L   `   `   `  ����F  BLoginScreen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:LoginScreenLoginScreen  5   	       LoginScreen.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:LoginScreen     5   	     � Title$  STUTOR��5   	   $	��450��6   $	��525��6%    � WindowStartupLocation$ CenterScreen=�61   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      $
��Auto �6   .+�5   
   o� $��0��6   .@�5      m� $
��File��6   .@�5      m� -   5        $��mnuQuit��5      $
��Quit��6*   $
��Left=�68   $
��Auto��6S   6`   5      m� 5      $
��Edit��6   .@�5      m� -   5        $��mnuPreferences��5      $��Preferences��61   $
��Left=�6F   $
��Auto��6a   5      m� 5      $
��Help��6   .@�5      m� -   5        $��mnuHelp��5      $
��Help��6*   $
��Left=�68   $
��Auto��6S   m� 5      -   5        $��mnuAbout��5      $��About��6+   $
��Left=�6:   $
��Auto��6U   6b   5      5      � 5    
   $��1��6   .+�5!      �� -   5        $��	lblStutor��5!      $��Welcome to STUTOR��6%   $��25(�6A   $��Center=�6O   $��Center=�6l   5"      � 5#   
   $��2��6   .+�5$      �� -   5        $��lblEmail��5$      $��University Email��6$   $��20(�6?   $��Center=�6M   $��Bottom=�6j   5%      � 5&   
   $��3��6   .+�5'      �� -   5        $��txtEmail��5'      $
��90 6q�6&   $��20(�64    �� TextAlignment$ Center=�6L   5(      � 5)   
   $��4��6   .+�5*      �� -   5        $��lblPassword��5*      $��Password��6'   $��20(�6:   $��Center=�6H   $��Bottom=�6e   5+      � 5,   
   $��5��6   .+�5-      G� -	   5        $��txtPassword��5-      $
��90 5q�6-   $��20(�6;    �� TextAlignment$ Center=�6S   6v   5.      � 5/   
   $��6��6    � ColumnDefinitions 50      �� 51      �� 52      .+�54      �� -
   5        $��btnLogin��54      $��0��6%   $��Login��65   $
��50 5q�6E   $��Center=�6T   $��Center=�6q    �� 	IsDefault . 6�   �� 55      -   5        $��btnCreateAccount��55      $��1��6-   $��Create Account��6=   $
��50 5q�6V   $��Center=�6e   $��Center=�6�   6�   56      �� 57   
   $��7��6   .@�58      �� -   5        $��statusMessage��58      $!��Welcome. Log in to continue��61   59      5:      5;      