   M S B A M L   `   `   `  ����H  DBestMessenger, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:BestMessenger.ViewsBestMessenger.Views  5   	   C&clr-namespace:BestMessenger.ViewModelsBestMessenger.ViewModels  5   	   ,    &BestMessenger.Views.RegistrationWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:BestMessenger.Views     5   	   5vm&clr-namespace:BestMessenger.ViewModels     5   	     � Title$  RegistrationWindow��5   	   $	��600��5	   	   $	��800��6    � AllowsTransparency .  ���#212121 � WindowStyle$
 None=�5   	    � 
ResizeMode$ CanResizeWithGrip=�5   	    � DataContext 5      4   .BestMessenger.ViewModels.RegistrationViewModel  5   
   6%   .��5      ]� .+�5   
   �� 
������ $	��Top=�6*   ._�5      � $��Stretch=�6   .+�5      �� $��Best Messenger��6   
�������$
��Bold"�5      �� 5       �� Orientation$ 
Horizontal=�6   $��Right=�5      .+�5      ��    MinimizeBtnStyle#��[  6   ��5      �� *WindowMinimizeCommand+�� 5         MaximizeBtnStyle#��[ 6   ��5!      �� *WindowMaximizeCommand+�� 5#        CloseWindowBtnStyle#��[ 6   ��5$      �� *CloseWindowCommand+5&      5'      5(      o� 5)   
   $	��Top=�6   .@�5*      m� $��Application��6   .@�5+      m� $��CloseApp��6   5-      5.      5/      �� 50   
   .+�51      �� $	��250��6   $��25q�6"   ��52      �� *	FirstName+63   �� 53      $��First name incorrect data��6   $��Center=�54      ��56      �� 57       �� 
TargetType" ��6   .�58      ��  �� Property � �� �� Value
 �  ��6E   �� 59       � y�$ 	Collapsed=�67   	 �� Triggers	 5:      �� 5;      
 �� Binding
 6*   �� *	NameValid+ �� Value	 False6H   .a�5<   "   ��  � y�$ Visible=�6?   5=      5?      5A      �� 5B      $	��250��6   $��20q�6"   ��5C      �� *
LastName+5D      �� 5E      $��Last name incorrect data��6   $��Center=�5F      
���  ��$y�	Collapsed=�5H      5I      �� 5J      $	��250��6   $��20q�6"   ��5K      �� *Email+5M      �� 5N      $��Email incorrect data��6   $��Center=�5O      ��5Q      �� 5R      " ��6   .�5S      ��  � ��
 �  ��6E   �� 5T       � y�$ 	Collapsed=�67   	 5U      �� 5V      
 6*   �� *
EmailValid+	 False6I   .a�5W   "   ��  � y�$ Visible=�6?   5X      5Z      5]      �� 5^      $	��250��6   $��20q�6"   ��5_      �� *
NickName+5`      �� 5a      $��NIckname incorrect data��6   $��Center=�5b      
���  ��$y�	Collapsed=�5d      5e      �� 5f      $	��250��6   $��20q�6"   ��5g      �� *
Password+5h      �� 5i      $��Password incorrect data��6   $��Center=�5j      
���  ��$y�	Collapsed=�5l      5m      �� 5n      $	��250��6   $��20q�6"   60   �� 5o      $!��Photo source incorrect data��6   $��Center=�5p      
���  ��$y�	Collapsed=�5r      5s      �� 5t      $	��150��6   $��20��6!   $��Register��6-   ��5y      �� 5z      " ��6   .�5{      ��  � �� 5|      �� 5}   "   .R�5~   &   �� #��z��6-   ��5   *   �� 5�   .    �� Color$ Black��6>   	btnCustom��5�   /   5�   '    �� Triggers 5�   &   :� 5�   *    :� RoutedEvent$ Button.Click��67   .[�5�   .   ��  ��Name$ 	textColor��6>   .��5�   2   �� .��5�   6   ��  �� 
TargetName$ 	btnCustom��6E    �� TargetProperty$ Color�5�   E    �� From$ BlackX�5�   E   	 �� To$	 RedX�6R    g� Duration$ 0:0:1D�5�   E    g� RepeatBehavior$ Forever��5�   E   5�   7   5�   3   5�   /   5�   +   :� 5�   *   $ MouseLeftButtonDown��67   .[�5�   .   ?�  �� BeginStoryboardName$ 	textColor��6>   5�   /   5�   +   :� 5�   *   $ 
MouseLeave��67   .[�5�   .   �� $ 	textColor��6=   5�   /   5�   +   5�   #   5�      5�      5�      5�      5�      5�      