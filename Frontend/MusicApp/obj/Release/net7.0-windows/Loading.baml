   M S B A M L   `   `   `  ���� 	  Music    Music.Loading   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     @d2http://schemas.microsoft.com/expression/blend/2008     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     U QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com  $	��800��$	��600��  � AllowsTransparency$
  True�����#181818 � SizeToContent$ WidthAndHeight=� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=� � Icon$ 	/icon.png��.���  � RowDefinitions �� $��70 ��� $��* �.+��� $��0��
���   �.+�� $��70�� � ColumnDefinitions �� $
��Auto ��� �� $
��Auto ��� $
��Auto �.+��� $��1��$��60,0,0,0q�$	��100��$��70��$��/View/logo.png���� $��3��$��Right=�$��Center=� �� Orientation$ 
Horizontal=�.+��� -   $��40��$��40��$��0,0,10,0q�
������ $��0q�$��X�� � Cursor$
 Hand��
����������� 	 �� 
TargetType"	 ��.��� 
 �� Property
 � �� �� Value$
 None{� �� Triggers P�  P� Property �@J�IsMouseOver P� Value$
 True��. ��� 
 � ��
 �  ��� $��1��.+�� $	��800��$	��450��.+�r� -   $��mediaElement1�� r� Source$B <E:\Sites\Новая папка\WPF_COURSE\Music\animate2.gif?� r� LoadedBehavior$
 Play=� r� Stretch$ Uniform=� r� IsMuted$ False��$��Stretch=�$��Stretch=��� $��Center=�.+��� -    ��Name$ txtLoadingDescription��$��Center=�$��Center=�$��24(�$
��Bold"�
�������$
��0 10q�$��
Loading...�� � Triggers :�  :� RoutedEvent$ FrameworkElement.Loaded��.[��� .���� .��W�  �� 
TargetName$ txtLoadingDescription�� �� TargetProperty$ Opacity� W� From 0	 W� To 1 g� Duration$ 0:0:1D�� -    �Name$ LoadingProgressBar��$	��200��$��20�� � Minimum$ 1Q�$��	0 0 10 20q� � Maximum$	 100Q� � Value$ 1Q����� "	 � :� $ FrameworkElement.Loaded��.[��� .���� .��W� $ Value� 1 100$ 0:0:3D�