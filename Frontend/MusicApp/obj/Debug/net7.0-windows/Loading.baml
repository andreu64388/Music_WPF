   M S B A M L   `   `   `  ����	  Music    Music.Loading   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $	��800��5   	   $	��600��5   	     � AllowsTransparency$
  True��5   	   ���#181818 � SizeToContent$ WidthAndHeight=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	    � Icon$ 	/icon.png��5   	   .��5      �  � RowDefinitions 5   
   �� 5      $��70 �6   �� 5      $��* �6   .+�5   
   �� $��0��6   
���   �.+�5      � $��70��6    � ColumnDefinitions 5      �� 5      $
��Auto �6'   �� 5      �� 5      $
��Auto �6'   �� 5      $
��Auto �6'   .+�5"      �� $��1��5#      $��60,0,0,0q�5$      $	��100��5%      $��70��5&      $��/View/logo.png��5'      �� 5(      $��3��5)      $��Right=�5*      $��Center=�5+       �� Orientation$ 
Horizontal=�5,      .+�5-      �� -   5        $��40��5-      $��40��5.   	   $��0,0,10,0q�5/   	   
������ $��0q�51   	   $��X��53   	    � Cursor$
 Hand��54   	   
���������56      �� 57      	 �� 
TargetType"	 ��6$   .�58   "   �� 
 �� Property
 � �� �� Value$
 None{�6N    �� Triggers 59   "   P� 5:   &    P� Property �@J�IsMouseOver P� Value$
 True��6E   . �5;   *   �� 
 � ��
 �  ��6U   5<   '   5>      5@      5A      5B      5C      � 5E   
   $��1��6   .+�5G      � $	��800��6   $	��450��6   .+�5I      r� -   5        $��mediaElement1��5J   	    r� Source$B <E:\Sites\Новая папка\WPF_COURSE\Music\animate2.gif?�5K   	    r� LoadedBehavior$
 Play=�5L   	    r� Stretch$ Uniform=�5M   	    r� IsMuted$ False��5N      $��Stretch=�5P   	   $��Stretch=�5R      5S      �� 5U      $��Center=�6   .+�5V      �� -   5         ��Name$ txtLoadingDescription��5W      $��Center=�5X      $��Center=�5Y      $��24(�5Z      $
��Bold"�5[      
�������$
��0 10q�5]      $��
Loading...��5^       � Triggers 5_      :� 5a       :� RoutedEvent$ FrameworkElement.Loaded��6'   .[�5b      �� .��5c   "   �� .��5d   &   W�  �� 
TargetName$ txtLoadingDescription��5e   !    �� TargetProperty$ Opacity�5f   !    W� From 05g   !   	 W� To 16*    g� Duration$ 0:0:1D�61   5h   #   5i      5j      5l      � 5n      -   5         �Name$ LoadingProgressBar��5o      $	��200��5p      $��20��5q       � Minimum$ 1Q�5r      $��	0 0 10 20q�5s       � Maximum$	 100Q�5t       � Value$ 1Q�5u      ��5v      �� 5w      "	 �6     5x      :� 5y   "   $ FrameworkElement.Loaded��6/   .[�5z   &   �� .��5{   *   �� .��5|   .   W� $ Value�5}   1    15~   1    1005   1   $ 0:0:3D�5�   1   5�   +   5�   '   5�   #   5�      5�      5�      5�      5�      5�      