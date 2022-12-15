using BoardSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexenSystem
{
    public class CardMovesCollection<TPiece>
    {
        private Dictionary<CardTypes, CardMove<TPiece>> _cardMoves = new Dictionary<CardTypes, CardMove<TPiece>>();

        public CardMovesCollection(Board<TPiece> board)
        {
            _cardMoves.Add(CardTypes.Teleport,
                new CardMove<TPiece>(board,
                (b, p, h) => new CardMoveHelper<TPiece>(p, h, b).CollectHover()
                                                                .ValidPosition()));
            
            _cardMoves.Add(CardTypes.Swipe,
                new CardMove<TPiece>(board,
                (b, p, h) => new CardMoveHelper<TPiece>(p, h, b).GetQDown(1)
                                                                .GetQUp(1)
                                                                .GetRDown(1)
                                                                .GetRUp(1)
                                                                .GetSDown(1)
                                                                .GetSUp(1)
                                                                .ValidPosition()));

            _cardMoves.Add(CardTypes.PushBack,
                new CardMove<TPiece>(board,
                (b, p, h) => new CardMoveHelper<TPiece>(p, h, b).GetQDown(1)
                                                                .GetQUp(1)
                                                                .GetRDown(1)
                                                                .GetRUp(1)
                                                                .GetSDown(1)
                                                                .GetSUp(1)
                                                                .ValidPosition()));

            _cardMoves.Add(CardTypes.Slash,
                new CardMove<TPiece>(board,
                (b, p, h) => new CardMoveHelper<TPiece>(p, h, b).GetQDown()
                                                                .GetQUp()
                                                                .GetRDown()
                                                                .GetRUp()
                                                                .GetSDown()
                                                                .GetSUp()
                                                                .ValidPosition()));
        }

        public CardMove<TPiece> For(CardTypes cardType)
        {
            return _cardMoves[cardType];
        }
    }
}
