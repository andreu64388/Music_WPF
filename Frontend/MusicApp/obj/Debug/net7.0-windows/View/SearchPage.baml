   M S B A M L   `   `   `  ����	  Music    Music.View.SearchPage   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        N� Title$  
SearchPage��5      .��5      � .+�5   
   �� .+�5      �� $��0,20,0,0q�5      $��Center=�5      $��Center=�5      $��30(�5      
�������$��Search��5      �� 5      $	��600��5      $��40q�5       �� Padding$ 10q�5      
������� �� CornerRadius$ 20��5      ._�5      � .+�5      �� $��Center=�5      $��Center=�5      $��25(�5      �� 5!      $��1��5"      
�������$ 5��5$      ._�5%      �  � ColumnDefinitions 5&      �� 5'   "   $	��80* �63   �� 5(   "   $	��20* �63   .+�5*      �� -   5        $��SearchTextBox��51   !   $��0��5+   !   
������ $��0q�5-   !   $��20(�5.   !    �� 	MaxLength$ 50��50   !   ��52   !   �� *SearchTitle+�� 53      $��1��54   !   $��30��55   !   $��30��56   !   $��Button��58   !    � Cursor$
 Hand��59   !   ��57   !   �� *SearchCommand+��5:   "   �� 5;   &    �� 
TargetType" ��66   .R�5<   *   � .+�5=   .   �� $��/View/search.png��64   $��Uniform=�6N   5>   +   5?   '   5A      5B      5C      5D      5E      �� 5F      -   5        $��LoadingText��5F      $��
Loading...��5G      $��Center=�6*   $��Center=�5H      $��23(�5I      
���������5K      �� 5L       �� 
TargetType" ��6   .�5M      ��  �� Property � y�	 �� Value$	 	Collapsed=�67   
 �� Triggers
 5N      �� 5O       �� Binding 6*   �� *	IsLoading+ �� Value True6H   .a�5P   "   ��  � y�$	 Visible=�6?   5Q      5S      5U      � 5W      $��Center=�6   $��Center=�65   ��5X      �� 5Y      " �6   .�5Z      ��  � y�$	 	Collapsed=�67   
 5[      �� 5\       6*   �� *Tracks.Count+ 06K   .a�5]   "   ��  � y�$	 Visible=�6?   5^      5`      .+�5c      �� $	��250��5d      $	��250��5e      $��10q�5f      $
��Rock��5h      $
 Hand��5i      $��30(�5j      
���������5g      �� *
Category+��5l      �� 5m      " ��6*   .R�5n      �� 
��� � �$ 10��67   ._�5o   "   �� $��Center=�63   $��Center=�6P   5p      5q      .��5r   '   Rock5t      �� 5u      $	��250��5v      $	��250��5w      $��10q�5x      $	��Pop��5z      $
 Hand��5{      $��30(�5|      
���������5y      �� *
Category+��5~      �� 5      " ��6*   .R�5�      �� ���	#FF000CA7$ 10��6<   ._�5�   "   �� $��Center=�63   $��Center=�6P   5�      5�      .��5�   '   Pop5�      �� 5�      $	��250��5�      $	��250��5�      $��10q�5�      $��Hip-Hop��5�      $
 Hand��5�      $��30(�5�      
���������5�      �� *
Category+��5�      �� 5�      " ��6*   .R�5�      �� ���	#FFFF8F8F$ 10��6<   ._�5�   "   �� $��Center=�63   $��Center=�6P   5�      5�      .��5�   '   	Hip-Hop5�      �� 5�      $	��250��5�      $	��250��5�      $��10q�5�      $��	Elecronic��5�      $
 Hand��5�      $��30(�5�      
���������5�      �� *
Category+��5�      �� 5�      " ��6*   .R�5�      �� ���	#FF7A55A2$ 10��6<   ._�5�   "   �� $��Center=�63   $��Center=�6P   5�      5�      .��5�   '   
Electronic5�      �� 5�      $	��250��5�      $	��250��5�      $��10q�5�      $
��Jazz��5�      $
 Hand��5�      $��30(�5�      
���������5�      �� *
Category+��5�      �� 5�      " ��6*   .R�5�      �� ���	#FFFFF217$ 10��6<   ._�5�   "   �� $��Center=�63   $��Center=�6P   5�      5�      .��5�   '   Jazz5�      5�      �� 5�      ��6   �� *Tracks+��5�      �� 5�      .R�5�      �� .+�5�      �� $��10q�5�   !   ���#282828$ 10��5�   !   ._�5�   "   �  5�   &   �� 5�   *   $
��Auto �6;   �� 5�   *   $��* �6;   �� 5�   *   $
��Auto �6;   .+�5�   &   �� $��0��5�   )   $��25��5�   )   $��25��5�   )   $��	20,0,20,0q�5�   )   $�� ��5�   )   $
 Hand��5�   )   ��5�   )   �� *DataContext.PlayCommand+ �� RelativeSource ��  �� AncestorType" N���5�   )   �� ��5�   *   �� 5�   .   " ��6>   .R�5�   2   � .+�5�   6   ��  ��Name$ PlayPauseImage��6<   5�   3    �� Triggers 5�   2   �� 5�   6   $
 True��6a    6B   �� *
IsSelected+.a�5�   :   ��  �� 
TargetName$ PlayPauseImage��6A    � ��$	 /View/pause.png��6o   5�   7   �� 5�   6   $ False��6a    6B   �� *
IsSelected+.a�5�   :   �� $ PlayPauseImage��6A    � ��$	 /View/play.png��6o   5�   7   5�   /   5�   '   �� 5�   &   $��1��61   $��10q�6A   .+�5�   *   �� $��18(�5�   -   
���������5�   -   �� *Title+�� 5�   *   $��16(�5�      $
 Hand��6   ��5�      �� *DataContext.ProfileCommand+ �� " N���5�      �� ��5�   .   �� 5�   2   " ��6B   .R�5�   6   �� 
������ 
������ ._�5�   :   �� 5�   7   5�   3   .��5�   .   �� 
���������6K   �� *	User.Name+5�   +   5�   '   �� 5�   &   $��2��5�   )   $��10q�5�   )    �� Orientation$ 
Horizontal=�5�   )   .+�5�   *   �� $��0,0,20,0q�5   -   $��Center=�5  -   $��Center=�5  -   $��18(�5  -   
���������5  -   �� *	PlayCount+�� 5  *   $��25��5  -   $��25��5  -   $�� ��5  -   $
 Hand��5  -   ��5	  -   �� *DataContext.LikeCommand+ �� " N���5
  -   �� ��5  .   �� 5  2   " ��6B   .R�5  6   � .+�5  :   �� $
 Like��6@   5  7    5  6   �� 5  :   $
 True��6b    6F   �� *	IsLiked+.a�5  >   �� $
 Like��6E    � ��$	 /View/redHeart.png��6i   5  ;   �� 5  :   $ False��6b    6F   �� *	IsLiked+.a�5  >   �� $
 Like��6E    � ��$	 /View/heart.png��6i   5  ;   5  3   5  +   �� 5  *   $��25��5  -   $��25��5  -   $��19,0,0,0q�5   -   $�� ��5#  -   $
 Hand��5$  -   ��5!  -   �� *DataContext.EditCommand+ �� " N���5"  -   �� ��5%  .   �� 5&  2   " ��6B   .R�5'  6   �� $��/View/dot.png��6<   $��Uniform=�6S   5(  3   5*  +   5+  '   5,  #   5-     5.     5/     51     52     53     54     