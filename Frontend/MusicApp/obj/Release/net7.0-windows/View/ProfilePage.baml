   M S B A M L   `   `   `  ���� 	  Music    Music.View.ProfilePage   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     @d2http://schemas.microsoft.com/expression/blend/2008     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       N� Title$  ProfilePage�� � 	Resources    PrimaryButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Triggers P� Property	 P� Value��%�  &	        �� " ��.���  � �� �#0078D7��  � ��
 �������  � ��$ 10q���  � ��$
 0,10q���  � ��$ 18(���  � ��$	 120����  � ��$ Center=���  � ��$ Center=���  � �� �� " ��.R��� #��z��#��z��$��1q�$ 5��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver$
	 True��. ���  � �� �#005A9EP�  � ��$
	 True��. ���  � �� �#003E6BP�  � {�$	 False��. ���  �@J�Opacity$	 0.5Q�.���� $��20q�.+��� $��Center=�$��30(�$
��Bold"�
�������$��Profile���� $
��0,20q�$��Center=�
 �� Orientation$
 
Horizontal=�.+��� $	��300��$��0,0,20,0q�.+��� $	��200��$	��200������ *mainViewModel.User.Image+�� $
��Left=�.+��� $��18(�$
��Bold"�
�������$
��Name���� $	��0,5q�$��16(�
����������� *mainViewModel.User.Name+�� $��18(�$
��Bold"�
�������$��Email���� $	��0,5q�$��16(�
����������� *mainViewModel.User.Email+�� $��18(�$
��Bold"�
�������$
��Role���� $	��0,5q�$��16(�
����������� *mainViewModel.User.Role+�� $��Center=�$��Center=�$
 
Horizontal=�.+��� $��18(�$
��Bold"�
�������$��User create at date: ���� $��Center=�$��18(�$
��Bold"�
����������� *mainViewModel.User.CreateAt+�� $��Center=�$��Center=�$
 
Horizontal=�.+��� $��18(�$
��Bold"�
�������$��User Update at date: ������ " ��.���  � y�$ Visible=� �� Triggers ��  �� Binding �� *mainViewModel.User.UpdateAt+ �� Value Z� .a���  � y�$ 	Collapsed=��� $��Center=�$��18(�$
��Bold"�
����������� *mainViewModel.User.UpdateAt+�� $
 
Horizontal=�$��Center=�$��Center=�.+��� $	��200��$��10q�$��Change Profile��#��[  ���� *EditCommand+�� $	��200��$��10q�
���  ��$��Delete account�� � Cursor$
 Hand��#��[  ���� *
DelCommand+