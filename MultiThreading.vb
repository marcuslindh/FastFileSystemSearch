Imports System.Threading

Public Class MultiThreading

    Private context As SynchronizationContext



    Public Sub New()

    End Sub

    Public Sub Run(ByVal fun As Action)

        context = SynchronizationContext.Current


        Task.Factory.StartNew(fun)

    End Sub

    Public Sub Run(ByVal fun As Action, after As Action)

        context = SynchronizationContext.Current


        Task.Factory.StartNew(fun).ContinueWith(Sub() after())

    End Sub

    Public Sub ThreadSafe(ByVal data As Object, ByVal func As SendOrPostCallback)
        context.Post(func, data)
    End Sub

End Class