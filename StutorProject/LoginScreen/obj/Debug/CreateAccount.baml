   M S B A M L   `   `   `  ����F  BLoginScreen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:LoginScreenLoginScreen  5   	       LoginScreen.CreateAccount   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:LoginScreen     5   	     � Title$  Account Application��5   	   $	��460��6%   $	��600��62    � WindowStartupLocation$ CenterScreen=�6>   .��5	      �  � RowDefinitions 5
   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      $
��auto �6   .+�5   
   � $��0��6   .+�5      �� -   5        $��lblAccountApplication��5      $��Account Application��61   $��Center=�6O   $��Center=�6l   $��25(�6�   $
��20 5q�6�   5      � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      �� 5      �� 5      .+�5      �� -   5        $��lblFirstname��5      $��
First Name��6(   $��19(�6=   $��0��6K   $��	25 15 0 0q�6[   �� 5      -   5        $��txtFirstname��5      $��1��6*   $��Center=�6:   $��20 10q�6U   �� 5       -   5        $��lblFirstnameMessage��5       $��2��6/   $%��Please Enter a Valid First Name��6?   $��Center=�6i   $
��Left=�6�   $
��5 10q�6�   
���  ��$y�Hidden=�6�   5!      � 5"   
   $��2��6    5#      �� 5$      �� 5%      �� 5&      .+�5(      �� -   5        $��lblLastname��5(      $��	Last Name��6'   $��19(�6;   $��0��6I   $��	25 15 0 0q�6Y   �� 5)      -   5        $��txtLastname��5)      $��1��6)   $��Center=�69   $��20 10q�6T   �� 5*      -   5        $��lblLastnameMessage��5*      $��2��6.   $$��Please Enter a Valid Last Name��6>   $��Center=�6g   $
��Left=�6�   $
��5 10q�6�   
���  ��$y�Hidden=�6�   5+      � 5,   
   $��3��6    5-      �� 5.      �� 5/      �� 50      .+�52      �� -   5        $��lblEmail��52      $��0��6$   $��Institution Email��64   $��19(�6P   $��	24 15 0 0q�6^   �� 53      -	   5        $��txtEmail��53      $��1��6&   $��Center=�66   $��20 10q�6Q   �� 54      -
   5        $��lblEmailMessage��54      $��2��6+   $,��&Please Enter a Valid Institution Email��6;   $��Center=�6l   $
��Left=�6�   $
��5 10q�6�   
���  ��$y�Hidden=�6�   55      � 56   
   $��4��6    57      �� 58      �� 59      �� 5:      .+�5<      �� -   5        $��lblPassword��5<      $��Password��6'   $��19(�6:   $��25 13q�6H   �� 5=      -   5        $��txtPassword��5=      $��1��6)   $��Center=�69   $��20 10q�6T   �� 5>      -   5        $��lblPasswordMessage��5>      $��2��6.   $#��Please Enter a Valid Password��6>   $��Center=�6f   $
��Left=�6�   $
��5 10q�6�   
���  ��$y�Hidden=�6�   5?      � 5@   
   $��5��6   $��0��6    5A      �� 5B      �� 5C      �� 5D      .+�5F      �� -   5        $��lblConfirmPassword��5F      $�� Confirm Password��6.   $��17(�6J   $��25 13q�6X   �� 5G      -   5        $��txtConfirmPassword��5G      $��1��60   $��Center=�6@   $��20 10q�6[   �� 5H      -   5        $��lblConfirmPasswordMessage��5H      $��2��65   $!��Your passwords do not match��6E   $��Center=�6k   $
��Left=�6�   $
��5 10q�6�   
���  ��$y�Hidden=�6�   5I      � 5J   
   $��7��6    5K      �� 5L      �� 5M      .+�5O      �� -   5        $��btnCreateApplication��5O      $��0��61   $��Create Account��6A   $��Center=�6Z   $��Center=�6w   $��20 10q�6�   6�   �� 5P      -   5        $��btnCancelApplication��5P      $��1��61   $��Cancel��6A   $��Center=�6R   $��Center=�6o   $��40 10q�6�   6�   5Q      �� 5R   
   $��9��6   .@�5S      �� -   5        $��statusMessage��5S      $#��Create a student account here��61   5T      5U      5V      