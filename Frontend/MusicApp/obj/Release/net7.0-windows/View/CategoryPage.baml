   M S B A M L   `   `   `  ���� 	  Music    Music.View.CategoryPage   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     @d2http://schemas.microsoft.com/expression/blend/2008     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       N� Title$  CategoryPage��.��� .+��� $��0,10,0,0q�.+��  � ColumnDefinitions �� $
��Auto ��� $��* �.+��� $��0��$��50��$��50��$��10q�$��Right=� � Cursor$
 Hand������ *BackCommand+����  �� 
TargetType" ��.R��  �� $
��Auto ��� $
��Auto �.+��� $��0��$��40��$��40��$��Center=�
���   � �� CornerRadius$ 15��._�F� $��
15,0,-15,0q�$��Center=�"����        р�� ��� �     -1	
�������$��2���� $��1��$��0,0,70,0q�$��Center=�$��Center=�$��30(�
����������� *Title+� .+��� $��Center=�$��30(�
�������$��	No tracks������  �� 
TargetType" ��.���  �� Property � y� �� Value$ 	Collapsed=� �� Triggers �� 	 �� Binding	 �� *Tracks.Count+
 �� Value
 0.a���  � y�$ Visible=��� -   $��LoadingText��$��
Loading...��$��Center=�$��Center=�$��23(�
����������� " ��.���  � y�$ 	Collapsed=� �� 	 �� *	IsLoading+
 True.a���  � y�$ Visible=�� $��Center=� � Orientation$ Vertical=�.+��� ���� *Tracks+���� .R�� $ 
Horizontal=����� .R��� $	��180��$	��180��$��10q�
�������$ 10��._��  � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��0��$	��150��$	��150��$��0,15,0,0q����� *Image+�� $��0��$��50��$��50��$��0,5,5,0q�$��Right=�$	��Top=�
������ $
 Hand������ *DataContext.PlayCommand+ �� RelativeSource ��  �� AncestorType" N����� ���� " ��.R�� .+�A� $��50��$��50��
��� � ���  ��Name$ PlayPauseImage��$��30��$��30��$��Center=�$��Center=� �� Triggers �� $

 True��	 �� *
IsSelected+.a���  �� 
TargetName$ PlayPauseImage�� � ��$ /View/pause.png���� $
 False��	 �� *
IsSelected+.a��� $ PlayPauseImage�� � ��$ /View/play.png���� $��1��$	��165��$��80��$��5q�.+��� $��WrapWithOverflow=�$��19(�$
��Bold"����� *Title+�� $��15(�$��WrapWithOverflow=����� *	User.Name+