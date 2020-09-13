using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class GooglePlayLoginSample : MonoBehaviour
{
    private void Awake()
    {
        //초기화 함수. 인스턴스를 만드는 역할.
        PlayGamesPlatform.InitializeInstance(new PlayGamesClientConfiguration.Builder().Build());
        //디버그용 변수
        PlayGamesPlatform.DebugLogEnabled = true;
        //구글 관련 서비스 활성화.
        PlayGamesPlatform.Activate();
    }

    public void Do_Login()
    {
        if(!Social.localUser.authenticated) //현재 기기와 연결된 계정이 인증이 아직 안됬는가?
        {
            //계정 인증
            Social.localUser.Authenticate((bool isSuccess) =>
            {
                if(isSuccess)
                {
                    Debug.Log("인증 성공 -> " + Social.localUser.userName);
                }
                else
                {
                    Debug.Log("인증 실패");
                }
            }
            );
        }
    }

    public void Do_Logout()
    {
        //로그아웃
        ((PlayGamesPlatform)Social.Active).SignOut();
    }

    public void Do_CompleteAchiv()
    {
        //진행상황 보고 함수.
        //1번 인자 : 보고할 업적 ID
        //2번 인자 : 보고할 업적의 진행척도
        //3번 인자 : callback 함수
        Social.ReportProgress(GPGSIds.achievement, 100.0f, (bool isSuccess) => {});
    }

    public void Do_ShowAchiv()
    {
        //업적 리스트 출력하기.
        Social.ShowAchievementsUI();
    }

    public void Do_ShowLeaderBoard()
    {
        //점수 보고 함수.
        //1번 인자 : 보고할 점수
        //2번 인자 : 보고할 대상 리더보드 ID값
        //3번 인자 : callback 함수
        Social.ReportScore(123, GPGSIds.leaderboard_testleaderboard, (bool isSuccess) => { });
        //리더보드 출력하기.
        Social.ShowLeaderboardUI();
    }
}
