using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.OS;
using Android.Content;

namespace MauiOSS.Platforms.Android
{
    internal class DownloadA
    {
        public DownloadA() 
        {
            var file = $"{FileSystem.AppDataDirectory}/{"com.masa.mauidemo.apk"}";

            var apkFile = new Java.IO.File(file);

            var intent = new Intent(Intent.ActionView);
            // 判断Android版本
            if (Build.VERSION.SdkInt >= BuildVersionCodes.N)
            {
                //给临时读取权限
                intent.SetFlags(ActivityFlags.GrantReadUriPermission);
                //var uri = FileProvider.GetUriForFile(Android.App.Application.Context, "com.masa.mauidemo.fileprovider", apkFile);
                // 设置显式 MIME 数据类型
                //intent.SetDataAndType(uri, "application/vnd.android.package-archive");
            }
            else
            {
                //intent.SetDataAndType(Android.Net.Uri.FromFile(new Java.IO.File(file)), "application/vnd.android.package-archive");
            }
            //指定以新任务的方式启动Activity
            intent.AddFlags(ActivityFlags.NewTask);

            //激活一个新的Activity
            //Android.App.Application.Context.StartActivity(intent);
        }
    }
}
