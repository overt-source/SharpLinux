"""
Generate sha sums from input.

Written by Chris Norman <chris.norman2@googlemail.com
For the SharpLinux project.
"""

from argparse import ArgumentParser, ArgumentDefaultsHelpFormatter
import hashlib

parser = ArgumentParser(
    description='Print sha sums.',
    formatter_class=ArgumentDefaultsHelpFormatter
)

parser.add_argument(
    'string',
    help='The string to return the sha for'
)

parser.add_argument(
    '-a',
    '--algorithm',
    default='sha512',
    choices=[x for x in dir(hashlib) if
             x.startswith('sha') and
             not x.startswith('shake')
             ],
    help='The algorithm to use'
)

if __name__ == '__main__':
    args = parser.parse_args()
    algo = getattr(hashlib, args.algorithm)
    print(
        algo(
            args.string.encode()
        ).hexdigest()
    )