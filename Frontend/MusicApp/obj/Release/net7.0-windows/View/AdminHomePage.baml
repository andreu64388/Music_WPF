   M S B A M L   `   `   `  ���� U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf  	 Music   Music.View.AdminHomePage   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       � 	Resources     CircleStyle �� 
TargetType �� Property �� Value��%�   &	        �� " A�.���  � ��$	 200����  � ��$	 200����  � ��
 ��ح���  � ��
 �   ���  � ��$ 2��.���� .+��� $��	0,20,0,20q�$��Center=�$��25(�
�������$��	Dashboard���� $��Center=� �� Orientation$ 
Horizontal=�.+��     
BlockStyle  ImageTextStyle��%�   &	       &	 |     �� " ��.���  � ��
 �������  � ��$ 10q���  �@��Padding$ 10q���  �@��CornerRadius$ 10���� " ��.���  � ��
 �   ���  � ��$ 10,0,0,0q�.+��� $	��240��#��[ ._��� $ 
Horizontal=�.+��� $��50��$��50��$��0,0,10,0q�$��/View/image.png���� $��	10,0,20,0q�$��Center=�$��Center=�$��24(�#��[ $��Users���� $��Center=�$��Center=�$��23(�#��[ ���� *CircleValue+�   ��%�   &	       &	 |     �� " ��.���  � ��
 �������  � ��$ 10q���  �@��Padding$ 10q���  �@��CornerRadius$ 10���� " ��.���  � ��
 �   ���  � ��$ 10,0,0,0q�.+��� $	��240��#��[ ._��� $ 
Horizontal=�.+��� $��50��$��50��$��0,0,10,0q�$��/View/songs..png���� $��	10,0,20,0q�$��Center=�$��Center=�$��24(�#��[ $��Tracks���� $��Center=�$��Center=�$��23(�#��[ ���� *CircleValueTracks+�   ��%�   &	       &	 |     �� " ��.���  � ��
 �������  � ��$ 10q���  �@��Padding$ 10q���  �@��CornerRadius$ 10���� " ��.���  � ��
 �   ���  � ��$ 10,0,0,0q�.+��� $	��200��#��[ ._��� $ 
Horizontal=�.+��� $��50��$��50��$��0,0,10,0q�$��/View/image.png���� $��	10,0,20,0q�$��Center=�$��Center=�$��24(�#��[ $��Users���� $��	0,20,0,20q�.+�� $��10q�
�������    HeaderCellStyle=  7System.Windows.Controls.Primitives.DataGridColumnHeader  CellContentStyle  ButtonStyle �� 
TargetType �� CornerRadius��%Q  &	       &	 q     &	      �� "  .���  � �� �#2BC48A��  � ��
 �������  � ��$ Center=���  � ��$ 10q��� " ��.���  � ��
 �   ���  � ��$ Center=���  � ��$ Center=���  �@��Padding$ 10q���  � ��$
 Wrap=��� " ��.���  � ��$ Delete����  � ��$ 1q���  � ��$
 10,5q���  � ��
 �  ����  � ��
 �������  � ��$ Center=���  � ��$ Center=���  �@�Cursor$
 Hand����  � �� �� " ��.R��� #��z��$��0q�$ 5��._��� $��Center=�$��Center=�.+�&   System.Windows.Controls.DataGrid  -   $��5q�   AutoGenerateColumns$ False��   CanUserAddRows$ False��	   CanUserDeleteRows$	 False��
   CanUserResizeColumns$
 False��   CanUserResizeRows$ False��   RowHeaderWidth$ 0Q�   	RowHeight$ 35Q����� *LimitedUsers+    CellBackground �� Color  CellForeground��%6   &	       &	      �� $ White���� $ Black��   	CellStyle �� *  $System.Windows.Controls.DataGridCell"  .���  � ��# [ ��  � ��# [ ��  � �� �� "  .R�� #��z��.+��� $��5q�$��Center=�$��Center=�   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ ID��   HeaderStyle# [ 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	user_id+   ElementStyle ��  �� BasedOn# [ " ��  $
 Name��# [  �� *	user_name+ �� # [ " ��  $ Email��# [  �� *
user_email+ �� # [ " ��  $
 Role��# [  �� *	role_name+ �� # [ " ��4  .System.Windows.Controls.DataGridTemplateColumn  $ Actions��# [    CellTemplate �� .R��� $��Center=�$ 
Horizontal=�.+��� -   $��Delete��#��[ �   ��%�   &	       &	 |     �� " ��.���  � ��
 �������  � ��$ 10q���  �@��Padding$ 10q���  �@��CornerRadius$ 10���� " ��.���  � ��
 �   ���  � ��$ 10,0,0,0q�.+��� $	��200��#��[ ._��� $ 
Horizontal=�.+��� $��50��$��50��$��0,0,10,0q�$��/View/songs..png���� $��	10,0,20,0q�$��Center=�$��Center=�$��24(�#��[ $��Tracks��� 
�������$��10q�  ��%Q  &	       &	 q     &	      �� "  .���  � �� �#2BC48A��  � ��
 �������  � ��$ Center=���  � ��$ 10q��� " ��.���  � ��
 �   ���  � ��$ Center=���  � ��$ Center=���  �@��Padding$ 10q���  � ��$
 Wrap=��� " ��.���  � ��$ Delete����  � ��$ 1q���  � ��$
 10,5q���  � ��
 �  ����  � ��
 �������  � ��$ Center=���  � ��$ Center=���  �@�Cursor$
 Hand����  � �� �� " ��.R��� #��z��$��0q�$ 5��._��� $��Center=�$��Center=�.+�  -   $��5q�$ False��$ False��$	 False��$
 False��$ False��$ 0Q�$ 35Q����� *LimitedTracks+  ��%6   &	       &	      �� $ White���� $ Black�� �� "  .���  � ��# [ ��  � ��# [ ��  � �� �� "  .R�� #��z��.+��� $��5q�$��Center=�$��Center=�   $ ID��# [  �� *
track_id+ �� # [ " ��  $ Title��# [  �� *track_title+ �� # [ " ��  $ Genre��# [  �� *
genre_name+ �� # [ " ��  $ 	artist_id��# [  �� *	artist_id+ �� # [ " ��  $ create_at_date��# [  �� *create_at_date+ �� # [ " ��  $ Actions��# [  �� .R��� $��Center=�$ 
Horizontal=�.+��� -   $��Delete��#��[ 