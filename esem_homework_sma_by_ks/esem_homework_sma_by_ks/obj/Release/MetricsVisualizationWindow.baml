   M S B A M L   `   `   `  ���� |  xSystem.Windows.Controls.DataVisualization.Toolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35�rclr-namespace:System.Windows.Controls.DataVisualization;assembly=System.Windows.Controls.DataVisualization.Toolkit)System.Windows.Controls.DataVisualization  �{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit2System.Windows.Controls.DataVisualization.Charting   esem_homework_sma_by_ks8   2esem_homework_sma_by_ks.MetricsVisualizationWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     �DVrclr-namespace:System.Windows.Controls.DataVisualization;assembly=System.Windows.Controls.DataVisualization.Toolkit     �DVC{clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit     -     � Title$   MetricsVisualizationWindow��$��422.804��$��974.688��.��� $��10,0,0,0q�.+�>   8System.Windows.Controls.DataVisualization.Charting.Chart  -   $��MetricChart��
 �� Top$ 80�� �� Left$ 10��$	��285��
�������$��	10,10,0,0q�$
��Left=�$	��Top=�$	��722��   Series E   ?System.Windows.Controls.DataVisualization.Charting.ColumnSeries  ?   9System.Windows.Controls.DataVisualization.Charting.Series   Title$ Metric��H   BSystem.Windows.Controls.DataVisualization.Charting.DataPointSeries   IndependentValueBinding ��  �� Path$	 Key�   DependentValueBinding �� $ Value�   DataPointStyle �� 	 �� 
TargetTypeH   BSystem.Windows.Controls.DataVisualization.Charting.ColumnDataPoint"	  .��� 
 �� Property
 � �� �� Value
 �k���   Axes C   =System.Windows.Controls.DataVisualization.Charting.LinearAxis  -     Name$ YLinearAxis��=   7System.Windows.Controls.DataVisualization.Charting.Axis   Orientation$ Y=�D   >System.Windows.Controls.DataVisualization.Charting.DisplayAxis   Title$ Percentages��
���   �
�������$��TimesNewRoman)�$��14(�$
��Bold"�   Interval�	   �System.Windows.Controls.DataVisualization.Charting.NullableConverter`1[[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]$ 10	   -   $ XLinearAxis��$ X=�$ 	Intervals��
���   �
�������$��TimesNewRoman)�$��14(�$
��Bold"��� -    ��Name$ MetricListBox��$
��Left=�$	��167��$��
750,10,0,0q�$	��Top=�$	��100���� $��Sample mean:��$
��Left=�$��750,194,0,0q�$	��Top=�$	��114���� -    ��Name$ StandardDeviationLabel��$�� ��$
��Left=�$��869,256,0,0q�$	��Top=��� $��	Variance:��$
��Left=�$��750,225,0,0q�$	��Top=�$	��114���� $��Standard Deviation:��$
��Left=�$��750,256,0,0q�$	��Top=��� $��	Kurtosis:��$
��Left=�$��750,287,0,0q�$	��Top=�$	��114���� $��	Skewness:��$
��Left=�$��750,318,0,0q�$	��Top=�$	��114���� -   $ VarianceLabel��$�� ��$
��Left=�$��869,225,0,0q�$	��Top=��� -   $ SampleMeanLabel��$�� ��$
��Left=�$��869,194,0,0q�$	��Top=��� -	   $ KurtosisLabel��$�� ��$
��Left=�$��869,287,0,0q�$	��Top=��� -
   $ SkewnessLabel��$�� ��$
��Left=�$��869,318,0,0q�$	��Top=��� -    ��Name$  NormalDistributionCheckBox��$��Normal Distribution��$
��Left=�$��
54,320,0,0q�$	��Top=��� -    ��Name$ 
NextButton��$
��Next��$
��Left=�$��
54,362,0,0q�$	��Top=�$��75��